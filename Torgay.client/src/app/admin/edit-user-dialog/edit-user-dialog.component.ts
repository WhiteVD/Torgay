import { Component, AfterViewInit, inject, viewChild } from '@angular/core';
import { CdkScrollable } from '@angular/cdk/scrolling';
import { MatButton } from '@angular/material/button';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { TranslateModule } from '@ngx-translate/core';

import { User } from '../../models/user.model';
import { Role } from '../../models/role.model';
import { UserEditorComponent } from '../user-editor/user-editor.component';

@Component({
    selector: 'app-edit-user-dialog',
    templateUrl: 'edit-user-dialog.component.html',
    styleUrl: 'edit-user-dialog.component.scss',
    imports: [
        MatDialogTitle, CdkScrollable, MatDialogContent, UserEditorComponent, MatDialogActions, MatButton, TranslateModule
    ]
})
export class EditUserDialogComponent implements AfterViewInit {
  dialogRef = inject<MatDialogRef<EditUserDialogComponent>>(MatDialogRef);
  data = inject<{ user: User, roles: Role[] }>(MAT_DIALOG_DATA);

  readonly editUser = viewChild.required(UserEditorComponent);

  get userName() {
    return this.data.user ? { name: this.data.user.userName } : null;
  }

  ngAfterViewInit() {
    this.editUser().userSaved$.subscribe(user => this.dialogRef.close(user));
  }

  cancel(): void {
    this.dialogRef.close(null);
  }
}
