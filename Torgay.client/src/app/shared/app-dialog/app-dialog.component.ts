// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { CdkScrollable } from '@angular/cdk/scrolling';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';

import { AlertDialog, DialogType } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';

@Component({
    selector: 'app-dialog',
    templateUrl: 'app-dialog.component.html',
    styleUrl: 'app-dialog.component.scss',
    imports: [
        MatDialogTitle, CdkScrollable, MatDialogContent, MatFormField, MatLabel, MatInput, FormsModule,
        MatDialogActions, MatButton
    ]
})
export class AppDialogComponent {
  dialogRef = inject<MatDialogRef<AppDialogComponent>>(MatDialogRef);
  private translationService = inject(AppTranslationService);
  private data = inject<AlertDialog>(MAT_DIALOG_DATA);

  result: string | undefined;

  ok() {
    if (this.data.type === DialogType.prompt) {
      this.data.okCallback?.(this.result || this.data.defaultValue);
    } else {
      this.data.okCallback?.();
    }
    this.dialogRef.close();
  }

  cancel(): void {
    if (this.data.cancelCallback) {
      this.data.cancelCallback();
    }
    this.dialogRef.close();
  }

  get showTitle() {
    return this.data.title && this.data.title.length;
  }

  get title() {
    return this.data.title;
  }

  get message() {
    return this.data.message;
  }

  get okLabel() {
    return this.data.okLabel || 'OK';
  }

  get cancelLabel() {
    return this.data.cancelLabel || 'CANCEL';
  }

  get showCancel() {
    return this.data.type !== DialogType.alert;
  }

  get isPrompt() {
    return this.data.type === DialogType.prompt;
  }
}
