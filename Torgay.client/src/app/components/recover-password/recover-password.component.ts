import { Component, inject, viewChild } from '@angular/core';
import { FormBuilder, NgForm, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { RouterLink } from '@angular/router';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatAnchor, MatButton } from '@angular/material/button';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AccountService } from '../../services/account.service';
import { Utilities } from '../../services/utilities';

@Component({
    selector: 'app-recover-password',
    templateUrl: './recover-password.component.html',
    styleUrl: './recover-password.component.scss',
    imports: [
        FormsModule, ReactiveFormsModule, MatFormField, MatLabel, MatInput, MatError, MatAnchor, RouterLink, MatButton,
        MatProgressSpinner
    ]
})
export class RecoverPasswordComponent {
  private alertService = inject(AlertService);
  private accountService = inject(AccountService);
  private fb = inject(FormBuilder);

  isLoading = false;
  isSuccess = false;

  recoverPasswordForm = this.fb.nonNullable.group({
    usernameOrEmail: ['', Validators.required]
  });

  readonly form = viewChild.required<NgForm>('form');

  getUsernameOrEmail() {
    return this.recoverPasswordForm.value.usernameOrEmail ?? '';
  }

  recover() {
    const form = this.form();
    if (!form.submitted) {
      // Causes validation to update.
      form.onSubmit(null as unknown as Event);
      return;
    }

    if (!this.recoverPasswordForm.valid) {
      this.alertService.showValidationError();
      return;
    }

    this.isLoading = true;
    this.alertService.startLoadingMessage('', 'Generating password reset mail...');

    this.accountService.recoverPassword(this.getUsernameOrEmail())
      .subscribe({ next: () => this.saveSuccessHelper(), error: error => this.saveFailedHelper(error) });
  }

  private saveSuccessHelper() {
    this.alertService.stopLoadingMessage();
    this.isLoading = false;
    this.isSuccess = true;
    this.alertService.showMessage('Recover Password', 'Password reset email sent', MessageSeverity.success);
  }

  private saveFailedHelper(error: HttpErrorResponse) {
    this.alertService.stopLoadingMessage();
    this.isLoading = false;
    this.isSuccess = false;

    const errorMessage = Utilities.getHttpResponseMessage(error);

    if (errorMessage) {
      this.alertService.showStickyMessage('Password Recovery Failed', errorMessage, MessageSeverity.error, error);
    } else {
      this.alertService.showStickyMessage('Password Recovery Failed',
        `An error occurred whilst recovering your password.\nError: ${Utilities.stringify(error)}`,
        MessageSeverity.error, error);
    }
  }

  get usernameOrEmail() {
    return this.recoverPasswordForm.controls.usernameOrEmail;
  }
}
