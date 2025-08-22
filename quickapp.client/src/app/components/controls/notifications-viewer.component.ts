// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, OnInit, AfterViewInit, OnDestroy, inject, viewChild } from '@angular/core';
import { MatProgressBar } from '@angular/material/progress-bar';
import { MatIconButton } from '@angular/material/button';
import { MatTooltip } from '@angular/material/tooltip';
import { MatIcon } from '@angular/material/icon';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort, MatSortHeader } from '@angular/material/sort';
import {
  MatTableDataSource, MatTable, MatColumnDef, MatHeaderCellDef, MatHeaderCell, MatCellDef, MatCell,
  MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow
} from '@angular/material/table';
import { Subscription } from 'rxjs';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { NotificationService } from '../../services/notification.service';
import { AccountService } from '../../services/account.service';
import { Permissions } from '../../models/permission.model';
import { Utilities } from '../../services/utilities';
import { Notification } from '../../models/notification.model';

@Component({
    selector: 'app-notifications-viewer',
    templateUrl: './notifications-viewer.component.html',
    styleUrl: './notifications-viewer.component.scss',
    imports: [
        MatProgressBar, MatTable, MatSort, MatColumnDef, MatHeaderCellDef, MatHeaderCell, MatSortHeader, MatCellDef, MatCell,
        MatIconButton, MatTooltip, MatIcon, MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow, MatPaginator, TranslateModule
    ]
})
export class NotificationsViewerComponent implements OnInit, AfterViewInit, OnDestroy {
  private alertService = inject(AlertService);
  private translationService = inject(AppTranslationService);
  private accountService = inject(AccountService);
  private notificationService = inject(NotificationService);
  private snackBar = inject(MatSnackBar);

  displayedColumns = ['date', 'header', 'actions'];
  dataSource: MatTableDataSource<Notification>;

  readonly paginator = viewChild.required(MatPaginator);

  readonly sort = viewChild.required(MatSort);

  loadingIndicator = false;

  dataLoadingConsecutiveFailures = 0;
  dataLoadingSubscription: Subscription | undefined;

  constructor() {
    this.dataSource = new MatTableDataSource<Notification>();
  }

  ngOnInit() {
    this.initDataLoading();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator();
    this.dataSource.sort = this.sort();
  }

  ngOnDestroy() {
    this.dataLoadingSubscription?.unsubscribe();
  }

  initDataLoading() {
    this.loadingIndicator = true;

    const dataLoadTask = this.notificationService.getNewNotificationsPeriodically();

    this.dataLoadingSubscription = dataLoadTask
      .subscribe({
        next: notifications => {
          this.loadingIndicator = false;
          this.dataLoadingConsecutiveFailures = 0;

          this.dataSource.data = notifications;
        },
        error: error => {
          this.loadingIndicator = false;

          this.alertService.showMessage('Load Error', 'Loading new notifications from the server failed!', MessageSeverity.warn);
          this.alertService.logError(error);

          if (this.dataLoadingConsecutiveFailures++ < 5) {
            setTimeout(() => this.initDataLoading(), 5000);
          } else {
            this.alertService.showStickyMessage('Load Error', 'Loading new notifications from the server failed!', MessageSeverity.error);
          }
        }
      });
  }

  getPrintedDate(value: Date) {
    if (value) {
      return Utilities.printTimeOnly(value) + ' on ' + Utilities.printDateOnly(value);
    }

    return '';
  }

  confirmDelete(notification: Notification) {
    this.snackBar.open(`Delete ${notification.header}?`, 'DELETE', { duration: 5000 })
      .onAction().subscribe(() => {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.notificationService.deleteNotification(notification)
          .subscribe({
            next: () => {
              this.alertService.stopLoadingMessage();
              this.loadingIndicator = false;

              this.dataSource.data = this.dataSource.data.filter(item => item.id !== notification.id);
            },
            error: error => {
              this.alertService.stopLoadingMessage();
              this.loadingIndicator = false;

              this.alertService.showStickyMessage('Delete Error',
                `An error occurred whilst deleting the notification.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
                MessageSeverity.error, error);
            }
          });
      });
  }

  togglePin(row: Notification) {
    const pin = !row.isPinned;
    const opText = pin ? 'Pinning' : 'Unpinning';

    this.alertService.startLoadingMessage(opText + '...');
    this.loadingIndicator = true;

    this.notificationService.pinUnpinNotification(row, pin)
      .subscribe({
        next: () => {
          this.alertService.stopLoadingMessage();
          this.loadingIndicator = false;

          row.isPinned = pin;
        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.loadingIndicator = false;

          this.alertService.showStickyMessage(opText + ' Error',
            `An error occurred whilst ${opText} the notification.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
            MessageSeverity.error, error);
        }
      });
  }

  get canManageNotifications() {
    return this.accountService.userHasPermission(Permissions.manageRoles);
  }
}
