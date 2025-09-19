import { Component, OnInit, AfterViewInit, inject, viewChild } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatProgressBar } from '@angular/material/progress-bar';
import { MatButton, MatIconButton } from '@angular/material/button';
import { MatTooltip } from '@angular/material/tooltip';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort, MatSortHeader } from '@angular/material/sort';
import {
  MatTableDataSource, MatTable, MatColumnDef, MatHeaderCellDef, MatHeaderCell, MatCellDef, MatCell,
  MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow
} from '@angular/material/table';
import { TranslateModule } from '@ngx-translate/core';

import { fadeInOut } from '../../services/animations';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { AccountService } from '../../services/account.service';
import { Utilities } from '../../services/utilities';
import { User } from '../../models/user.model';
import { Role } from '../../models/role.model';
import { Permissions } from '../../models/permission.model';
import { EditUserDialogComponent } from '../edit-user-dialog/edit-user-dialog.component';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
    styleUrl: './user-list.component.scss',
    animations: [fadeInOut],
    imports: [
        PageHeaderComponent, MatFormField, MatLabel, MatInput, MatProgressBar, MatTable, MatSort, MatColumnDef,
        MatHeaderCellDef, MatHeaderCell, MatSortHeader, MatCellDef, MatCell, MatButton, MatTooltip, MatIcon, MatIconButton,
        MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow, MatPaginator, TranslateModule
    ]
})
export class UserListComponent implements OnInit, AfterViewInit {
  private alertService = inject(AlertService);
  private translationService = inject(AppTranslationService);
  private accountService = inject(AccountService);
  private snackBar = inject(MatSnackBar);
  private dialog = inject(MatDialog);

  displayedColumns = ['jobTitle', 'userName', 'fullName', 'email'];
  dataSource: MatTableDataSource<User>;
  allRoles: Role[] = [];
  sourceUser: User | null = null;
  loadingIndicator = false;

  readonly paginator = viewChild.required(MatPaginator);

  readonly sort = viewChild.required(MatSort);

  constructor() {


    if (this.canManageUsers) {
      this.displayedColumns.push('actions');
    }

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.loadData();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator();
    this.dataSource.sort = this.sort();
  }

  public applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue;
  }

  private refresh() {
    // Causes the filter to refresh there by updating with recently added data.
    this.applyFilter(this.dataSource.filter);
  }

  private updateUsers(user: User) {
    if (this.sourceUser) {
      Object.assign(this.sourceUser, user);
      this.alertService.showMessage('Success', `Changes to user "${user.userName}" was saved successfully`, MessageSeverity.success);
      this.sourceUser = null;
    } else {
      this.dataSource.data.push(user);
      this.refresh();
      this.alertService.showMessage('Success', `User "${user.userName}" was created successfully`, MessageSeverity.success);
    }
  }

  private loadData() {
    this.alertService.startLoadingMessage();
    this.loadingIndicator = true;

    if (this.canViewRoles) {
      this.accountService.getUsersAndRoles().subscribe({
        next: results => this.onDataLoadSuccessful(results[0], results[1]),
        error: error => this.onDataLoadFailed(error)
      });
    } else {
      this.accountService.getUsers().subscribe({
        next: users => this.onDataLoadSuccessful(users, this.accountService.currentUser?.roles.map(r => new Role(r)) ?? []),
        error: error => this.onDataLoadFailed(error)
      });
    }
  }

  private onDataLoadSuccessful(users: User[], roles: Role[]) {
    this.alertService.stopLoadingMessage();
    this.loadingIndicator = false;
    this.dataSource.data = users;
    this.allRoles = roles;
  }

  private onDataLoadFailed(error: HttpErrorResponse) {
    this.alertService.stopLoadingMessage();
    this.loadingIndicator = false;

    this.alertService.showStickyMessage('Load Error',
      `Unable to retrieve users from the server.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
      MessageSeverity.error, error);
  }

  public editUser(user?: User) {
    this.sourceUser = user ?? null;

    const dialogRef = this.dialog.open(EditUserDialogComponent,
      {
        panelClass: 'mat-dialog-lg',
        data: { user, roles: [...this.allRoles] }
      });
    dialogRef.afterClosed().subscribe(u => {
      if (u) {
        this.updateUsers(u);
      }
    });
  }

  public confirmDelete(user: User) {
    this.snackBar.open(`Delete ${user.userName}?`, 'DELETE', { duration: 5000 })
      .onAction().subscribe(() => {
        this.alertService.startLoadingMessage('Deleting...');
        this.loadingIndicator = true;

        this.accountService.deleteUser(user)
          .subscribe({
            next: () => {
              this.alertService.stopLoadingMessage();
              this.loadingIndicator = false;
              this.dataSource.data = this.dataSource.data.filter(item => item !== user);
            },
            error: error => {
              this.alertService.stopLoadingMessage();
              this.loadingIndicator = false;

              this.alertService.showStickyMessage('Delete Error',
                `An error occurred whilst deleting the user.\r\nError: "${Utilities.getHttpResponseMessage(error)}"`,
                MessageSeverity.error, error);
            }
          });
      });
  }

  get canManageUsers() {
    return this.accountService.userHasPermission(Permissions.manageUsers);
  }

  get canViewRoles() {
    return this.accountService.userHasPermission(Permissions.viewRoles);
  }

  get canAssignRoles() {
    return this.accountService.userHasPermission(Permissions.assignRoles);
  }
}
