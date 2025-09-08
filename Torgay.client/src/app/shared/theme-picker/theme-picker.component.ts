// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, ViewEncapsulation, ChangeDetectionStrategy, inject, input } from '@angular/core';

import { MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenuTrigger, MatMenu, MatMenuItem } from '@angular/material/menu';
import { MatTooltip } from '@angular/material/tooltip';
import { TranslateModule } from '@ngx-translate/core';

import { ThemeManager } from './theme-manager';
import { AppTheme } from '../../models/AppTheme';
import { ConfigurationService } from '../../services/configuration.service';

@Component({
    selector: 'app-theme-picker',
    templateUrl: 'theme-picker.component.html',
    styleUrl: 'theme-picker.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None,
    imports: [MatIconButton, MatMenuTrigger, MatTooltip, MatIcon, MatMenu, MatMenuItem, TranslateModule]
})
export class ThemePickerComponent {
  themeManager = inject(ThemeManager);
  private configuration = inject(ConfigurationService);

  readonly tooltip = input('Theme');

  constructor() {
    const configuration = this.configuration;

    configuration.configurationImported$.subscribe(() => this.setTheme(this.currentTheme));
    this.setTheme(this.currentTheme);
  }

  get currentTheme(): AppTheme {
    return this.themeManager.getThemeByID(this.configuration.themeId);
  }

  setTheme(theme: AppTheme) {
    if (theme) {
      this.themeManager.installTheme(theme);
      this.configuration.themeId = theme.id;
    }
  }
}
