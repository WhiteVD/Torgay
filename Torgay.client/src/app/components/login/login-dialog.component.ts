import { Component, AfterViewInit, inject, viewChild } from '@angular/core';
import { CdkScrollable } from '@angular/cdk/scrolling';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions } from
  '@angular/material/dialog';
import { MatButton } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { TranslateModule } from '@ngx-translate/core';

import { LoginControlComponent } from './login-control.component';

@Component({
    selector: 'app-login-dialog',
    templateUrl: 'login-dialog.component.html',
    styleUrl: 'login-dialog.component.scss',
    imports: [
        MatDialogTitle, CdkScrollable, MatDialogContent, LoginControlComponent, MatDialogActions, MatButton, MatDivider,
        MatIcon, MatProgressSpinner, TranslateModule
    ]
})
export class LoginDialogComponent implements AfterViewInit {
  dialogRef = inject<MatDialogRef<LoginDialogComponent>>(MatDialogRef);
  data = inject(MAT_DIALOG_DATA);

  readonly loginControl = viewChild.required(LoginControlComponent);

  ngAfterViewInit() {
    this.loginControl().modalClosedCallback = () => this.dialogRef.close(true);
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
