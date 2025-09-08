// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatFormField, MatLabel, MatHint } from '@angular/material/form-field';
import { MatSelect, MatSelectTrigger } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatIcon } from '@angular/material/icon';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { MatTooltip } from '@angular/material/tooltip';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { ConfigurationService } from '../../services/configuration.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { AccountService } from '../../services/account.service';
import { Utilities } from '../../services/utilities';

export interface PageInfo {
  title: string;
  icon: string;
  path: string;
  isDefault: boolean;
}

export interface LanguagePreference {
  name: string;
  locale: string;
  isDefault: boolean;
}

@Component({
    selector: 'app-user-preferences',
    templateUrl: './user-preferences.component.html',
    styleUrl: './user-preferences.component.scss',
    imports: [
        MatFormField, MatLabel, MatSelect, FormsModule, MatOption, MatHint, MatSelectTrigger, MatIcon, MatSlideToggle,
        MatTooltip, TranslateModule
    ]
})
export class UserPreferencesComponent {
  private alertService = inject(AlertService);
  private translationService = inject(AppTranslationService);
  private accountService = inject(AccountService);
  private snackBar = inject(MatSnackBar);
  configurations = inject(ConfigurationService);

  gT = (key: string | string[]) => this.translationService.getTranslation(key);

  languages: LanguagePreference[] = [
    { name: 'English', locale: 'en', isDefault: false },
    { name: 'Russian', locale: 'ru', isDefault: true },
    { name: 'Kazakh', locale: 'kz', isDefault: false }
  ];

  homePages: PageInfo[] = [
    { title: 'Dashboard', icon: 'dashboard', path: '/', isDefault: true },
    { title: 'Customers', icon: 'contacts', path: '/customers', isDefault: false },
    { title: 'Products', icon: 'local_shipping', path: '/products', isDefault: false },
    { title: 'Orders', icon: 'credit_card', path: '/orders', isDefault: false },
    { title: 'About', icon: 'info', path: '/about', isDefault: false },
    { title: 'Settings', icon: 'settings', path: '/settings', isDefault: false }
  ];

  get currentHomePage(): PageInfo {
    return this.homePages.find(x => x.path === this.configurations.homeUrl) || this.homePages[0];
  }

  reload() {
    this.snackBar.open(this.gT('preferences.ReloadPreferences'), this.gT('preferences.RELOAD'), { duration: 5000 })
      .onAction().subscribe(() => {
        this.alertService.startLoadingMessage();

        this.accountService.getUserPreferences()
          .subscribe({
            next: results => {
              this.alertService.stopLoadingMessage();

              this.configurations.import(results);

              this.alertService.showMessage(this.gT('preferences.DefaultsLoaded'), '', MessageSeverity.info);

            },
            error: error => {
              this.alertService.stopLoadingMessage();
              this.alertService.showStickyMessage('Load Error',
                `Unable to retrieve user preferences from the server.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
                MessageSeverity.error, error);
            }
          });
      });
  }

  save() {
    this.snackBar.open(this.gT('preferences.SavePreferences'), this.gT('preferences.SAVE'), { duration: 5000 })
      .onAction().subscribe(() => {
        this.alertService.startLoadingMessage('', this.gT('preferences.SavingNewDefaults'));

        this.accountService.updateUserPreferences(this.configurations.export())
          .subscribe({
            next: () => {
              this.alertService.stopLoadingMessage();
              this.alertService.showMessage(this.gT('preferences.NewDefaults'),
                this.gT('preferences.AccountDefaultsUpdatedSuccessfully'), MessageSeverity.success);

            },
            error: error => {
              this.alertService.stopLoadingMessage();
              this.alertService.showStickyMessage('Save Error',
                `An error occurred whilst saving configuration defaults.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
                MessageSeverity.error, error);
            }
          });
      });
  }

  reset() {
    this.snackBar.open(this.gT('preferences.ResetPreferences'), this.gT('preferences.RESET'), { duration: 5000 })
      .onAction().subscribe(() => {
        this.configurations.import(null);
        this.alertService.showMessage(this.gT('preferences.DefaultsReset'),
          this.gT('preferences.AccountDefaultsResetSuccessfully'), MessageSeverity.success);
      });
  }
}
