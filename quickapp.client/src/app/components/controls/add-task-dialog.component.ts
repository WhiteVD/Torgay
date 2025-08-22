// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, inject } from '@angular/core';
import { FormBuilder, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CdkScrollable } from '@angular/cdk/scrolling';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatButton } from '@angular/material/button';
import { MatDialogRef, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { ToDoTask } from './todo-demo.component';

@Component({
    selector: 'app-add-task-dialog',
    templateUrl: 'add-task-dialog.component.html',
    styleUrl: 'add-task-dialog.component.scss',
    imports: [
        MatDialogTitle, CdkScrollable, MatDialogContent, FormsModule, ReactiveFormsModule, MatFormField, MatLabel,
        MatInput, MatError, MatCheckbox, MatDialogActions, MatButton, TranslateModule
    ]
})
export class AddTaskDialogComponent {
  dialogRef = inject<MatDialogRef<AddTaskDialogComponent>>(MatDialogRef);
  private alertService = inject(AlertService);
  private translationService = inject(AppTranslationService);
  private formBuilder = inject(FormBuilder);

  taskForm = this.formBuilder.nonNullable.group({
    taskName: ['', Validators.required],
    description: '',
    isImportant: false as boolean
  });

  save() {
    if (this.taskForm.valid) {
      const formModel = this.taskForm.value;

      const newtask: ToDoTask = {
        name: formModel.taskName ?? '',
        description: formModel.description ?? '',
        isImportant: formModel.isImportant ?? false,
        isComplete: false
      };

      this.dialogRef.close(newtask);
    } else {
      this.alertService.showStickyMessage(this.translationService.getTranslation('form.ErrorCaption'),
        this.translationService.getTranslation('form.ErrorMessage'), MessageSeverity.error);
    }
  }

  cancel(): void {
    this.dialogRef.close(null);
  }

  get taskName() {
    return this.taskForm.controls.taskName;
  }
}
