// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, ChangeDetectorRef, OnInit, OnDestroy, inject, Renderer2, viewChild } from '@angular/core';
import { MediaMatcher } from '@angular/cdk/layout';
import { Router, NavigationStart, RouterLink, RouterLinkActive, RouterOutlet, IsActiveMatchOptions } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatExpansionPanel } from '@angular/material/expansion';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { Subscription } from 'rxjs';
import { ToastaService, ToastaConfig, ToastOptions, ToastData, ToastaModule } from 'ngx-toasta';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, AlertCommand, MessageSeverity } from './services/alert.service';
import { NotificationService } from './services/notification.service';
import { AppTranslationService } from './services/app-translation.service';
import { AccountService } from './services/account.service';
import { LocalStoreManager } from './services/local-store-manager.service';
import { AppTitleService } from './services/app-title.service';
import { AuthService } from './services/auth.service';
import { ConfigurationService } from './services/configuration.service';
import { Permissions } from './models/permission.model';
import { LoginDialogComponent } from './components/login/login-dialog.component';
import { AppDialogComponent } from './shared/app-dialog/app-dialog.component';
import { ThemePickerComponent } from './shared/theme-picker/theme-picker.component';
import { FooterComponent } from './shared/footer/footer.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterLink, MatToolbarModule, MatSidenavModule, MatIconModule,
        MatMenuModule, MatTooltipModule, MatExpansionModule, MatListModule, MatButtonModule,
        FooterComponent, ThemePickerComponent, RouterLinkActive, RouterOutlet, ToastaModule, TranslateModule]
})
export class AppComponent implements OnInit, OnDestroy {
  private toastaService = inject(ToastaService);
  private toastaConfig = inject(ToastaConfig);
  private accountService = inject(AccountService);
  private alertService = inject(AlertService);
  private notificationService = inject(NotificationService);
  private authService = inject(AuthService);
  private translationService = inject(AppTranslationService);
  private matIconRegistry = inject(MatIconRegistry);
  configurations = inject(ConfigurationService);
  router = inject(Router);
  dialog = inject(MatDialog);
  renderer = inject(Renderer2);

  readonly adminExpander = viewChild<MatExpansionPanel>('admin');

  private readonly _mobileQueryListener: () => void;
  isUserLoggedIn = false;
  isAdminExpanded = false;
  newNotificationCount = 0;
  appTitle = '';

  mobileQuery: MediaQueryList;
  stickyToasties: number[] = [];

  dataLoadingConsecutiveFailures = 0;
  notificationsLoadingSubscription: Subscription | undefined;
  languageChangedSubscription: Subscription | undefined;

  gT = (key: string | string[], interpolateParams?: object) =>
    this.translationService.getTranslation(key, interpolateParams);

  get notificationsTitle() {
    if (this.newNotificationCount) {
      return `${this.gT('app.Notifications')} (${this.newNotificationCount} ${this.gT('app.New')})`;
    } else {
      return this.gT('app.Notifications');
    }
  }

  constructor() {
    const storageManager = inject(LocalStoreManager);
    const domSanitizer = inject(DomSanitizer);
    const changeDetectorRef = inject(ChangeDetectorRef);
    const media = inject(MediaMatcher);


    this.matIconRegistry.addSvgIconSet(domSanitizer.bypassSecurityTrustResourceUrl('custom-icons.svg'));

    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.addEventListener(this.mobileQuery, this._mobileQueryListener);

    storageManager.initialiseStorageSyncListener();

    this.toastaConfig.theme = 'material';
    this.toastaConfig.position = 'top-right';
    this.toastaConfig.limit = 100;
    this.toastaConfig.showClose = true;
    this.toastaConfig.showDuration = false;

    AppTitleService.appName = this.appTitle;
  }

  ngOnInit() {
    this.isUserLoggedIn = this.authService.isLoggedIn;

    setTimeout(() => {
      if (this.isUserLoggedIn) {
        this.alertService.resetStickyMessage();
        this.alertService.showMessage(this.gT('app.Login'), this.gT('app.WelcomeBack', { userName: this.userName }),
          MessageSeverity.default);
      }
    }, 2000);

    this.languageChangedSubscription = this.translationService.languageChanged$
      .subscribe(event => {
        this.renderer.setAttribute(document.documentElement, 'dir', event.lang === 'ar' ? 'rtl' : 'ltr');
        this.renderer.setAttribute(document.documentElement, 'lang', event.lang);
      });

    this.alertService.getDialogEvent().subscribe(alert => this.dialog.open(AppDialogComponent,
      {
        data: alert,
        panelClass: 'mat-dialog-sm'
      }));

    this.alertService.getMessageEvent().subscribe(message => this.showToast(message));

    this.authService.reLoginDelegate = () => this.showLoginDialog();

    this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
      this.isUserLoggedIn = isLoggedIn;

      if (this.isUserLoggedIn) {

        this.initNotificationsLoading();
      } else {
        this.unsubscribeNotifications();
      }

      setTimeout(() => {
        if (!this.isUserLoggedIn) {
          this.alertService.showMessage(this.gT('app.SessionEnded'), '', MessageSeverity.default);
        }
      }, 500);
    });

    this.refreshAdminExpanderState(this.router.url);

    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.refreshAdminExpanderState((event as NavigationStart).url);
      }
    });
  }

  ngOnDestroy() {
    this.removeEventListener(this.mobileQuery, this._mobileQueryListener);
    this.unsubscribeNotifications();
    this.languageChangedSubscription?.unsubscribe();
  }

  private addEventListener(mediaQuery: MediaQueryList, listener: () => void) {
    if (typeof mediaQuery.addEventListener === "function") {
      mediaQuery.addEventListener("change", listener)
    } else {
      mediaQuery.addListener(listener); // https://github.com/mdn/sprints/issues/858 for Safari < 14
    }
  }

  private removeEventListener(mediaQuery: MediaQueryList, listener: () => void) {
    if (typeof mediaQuery.removeEventListener === "function") {
      mediaQuery.removeEventListener("change", listener,)
    } else {
      mediaQuery.removeListener(listener); // https://github.com/mdn/sprints/issues/858 for Safari < 14
    }
  }

  private unsubscribeNotifications() {
    this.notificationsLoadingSubscription?.unsubscribe();
  }

  private refreshAdminExpanderState(currentUrl: string) {
    setTimeout(() => {
      const adminExpander = this.adminExpander();
      if (adminExpander && currentUrl.toLowerCase().indexOf('admin') > 0) {
        adminExpander.open();
      }
    }, 200);
  }

  isRouteActive(
    url: string,
    matchOptions: IsActiveMatchOptions = {
      paths: 'exact',
      queryParams: 'ignored',
      fragment: 'ignored',
      matrixParams: 'ignored'
    }) {
    return this.router.isActive(url, matchOptions);
  }

  initNotificationsLoading() {
    this.notificationsLoadingSubscription = this.notificationService.getNewNotificationsPeriodically()
      .subscribe({
        next: notifications => {
          this.dataLoadingConsecutiveFailures = 0;
          this.newNotificationCount = notifications.filter(n => !n.isRead).length;
        },
        error: error => {
          this.alertService.logError(error);

          if (this.dataLoadingConsecutiveFailures++ < 20) {
            setTimeout(() => this.initNotificationsLoading(), 5000);
          } else {
            this.alertService.showStickyMessage('Load Error', 'Loading new notifications from the server failed!',
              MessageSeverity.error);
          }
        }
      });
  }

  markNotificationsAsRead() {
    const newNotifications = this.notificationService.newNotifications;

    if (newNotifications) {
      this.notificationService.readUnreadNotification(newNotifications.map(n => n.id), true)
        .subscribe({
          next: () => {
            for (const n of newNotifications) {
              n.isRead = true;
            }

            this.newNotificationCount = newNotifications.filter(n => !n.isRead).length;
          },
          error: error => {
            this.alertService.logError(error);
            this.alertService.showMessage('Notification Error', 'Marking read notifications failed',
              MessageSeverity.error);
          }
        });
    }
  }

  showLoginDialog(): void {
    this.alertService.showStickyMessage(this.gT('app.SessionExpired'), this.gT('app.SessionExpiredLoginAgain'),
      MessageSeverity.info);

    const dialogRef = this.dialog.open(LoginDialogComponent, { minWidth: 300 });

    dialogRef.afterClosed().subscribe(result => {
      this.alertService.resetStickyMessage();

      if (!result || this.authService.isSessionExpired) {
        this.authService.logout();
        this.router.navigateByUrl('/login');
        this.alertService.showStickyMessage(this.gT('app.SessionExpired'),
          this.gT('app.SessionExpiredLoginToRenew'), MessageSeverity.warn);
      }
    });
  }

  showToast(alert: AlertCommand) {
    if (alert.operation === 'clear') {
      for (const id of this.stickyToasties.slice(0)) {
        this.toastaService.clear(id);
      }
      return;
    }

    const toastOptions: ToastOptions = {
      title: alert.message?.summary,
      msg: alert.message?.detail,
    };

    if (alert.operation === 'add_sticky') {
      toastOptions.timeout = 0;

      toastOptions.onAdd = (toast: ToastData) => {
        this.stickyToasties.push(toast.id);
      };

      toastOptions.onRemove = (toast: ToastData) => {
        const index = this.stickyToasties.indexOf(toast.id, 0);

        if (index > -1) {
          this.stickyToasties.splice(index, 1);
        }

        if (alert.onRemove) {
          alert.onRemove();
        }

        toast.onAdd = undefined;
        toast.onRemove = undefined;
      };
    } else {
      toastOptions.timeout = 4000;
    }

    switch (alert.message?.severity) {
      case MessageSeverity.default: this.toastaService.default(toastOptions); break;
      case MessageSeverity.info: this.toastaService.info(toastOptions); break;
      case MessageSeverity.success: this.toastaService.success(toastOptions); break;
      case MessageSeverity.error: this.toastaService.error(toastOptions); break;
      case MessageSeverity.warn: this.toastaService.warning(toastOptions); break;
      case MessageSeverity.wait: this.toastaService.wait(toastOptions); break;
    }
  }

  logout() {
    this.authService.logout();
    this.authService.redirectLogoutUser();
  }

  get userName(): string {
    return this.authService.currentUser?.userName ?? '';
  }

  get fullName(): string {
    return this.authService.currentUser?.fullName ?? '';
  }

  get canViewCustomers() {
    return this.accountService.userHasPermission(Permissions.viewUsers); // eg. viewCustomersPermission
  }

  get canViewProducts() {
    return this.accountService.userHasPermission(Permissions.viewUsers); // eg. viewProductsPermission
  }

  get canViewOrders() {
    return !!true; // eg. viewOrdersPermission
  }

  get canViewUsers() {
    return this.accountService.userHasPermission(Permissions.viewUsers);
  }

  get canViewRoles() {
    return this.accountService.userHasPermission(Permissions.viewRoles);
  }
}
