// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, AfterViewInit, inject, viewChild } from '@angular/core';
import { CdkScrollable } from '@angular/cdk/scrolling';
import { MatButton } from '@angular/material/button';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { TranslateModule } from '@ngx-translate/core';

import { AccountService } from '../../services/account.service';
import { Role } from '../../models/role.model';
import { Permission, Permissions } from '../../models/permission.model';
import { RoleEditorComponent } from '../role-editor/role-editor.component';

@Component({
    selector: 'app-edit-user-dialog',
    templateUrl: 'edit-role-dialog.component.html',
    styleUrl: 'edit-role-dialog.component.scss',
    imports: [
        MatDialogTitle, CdkScrollable, MatDialogContent, RoleEditorComponent, MatDialogActions, MatButton, TranslateModule
    ]
})
export class EditRoleDialogComponent implements AfterViewInit {
  dialogRef = inject<MatDialogRef<RoleEditorComponent>>(MatDialogRef);
  data = inject<{ role: Role, allPermissions: Permission[] }>(MAT_DIALOG_DATA);
  private accountService = inject(AccountService);

  readonly roleEditor = viewChild.required(RoleEditorComponent);

  get roleName() {
    return this.data.role ? { name: this.data.role.name } : null;
  }

  ngAfterViewInit() {
    this.roleEditor().roleSaved$.subscribe(role => this.dialogRef.close(role));
  }

  cancel(): void {
    this.dialogRef.close(null);
  }

  get canManageRoles() {
    return this.accountService.userHasPermission(Permissions.manageRoles);
  }
}
