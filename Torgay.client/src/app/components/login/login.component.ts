// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, viewChild } from '@angular/core';
import { UpperCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButton, MatAnchor } from '@angular/material/button';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule } from '@ngx-translate/core';

import { LoginControlComponent } from './login-control.component';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    imports: [
        LoginControlComponent, MatButton, MatProgressSpinner, MatAnchor, RouterLink, MatDivider, MatIcon, UpperCasePipe,
        TranslateModule
    ]
})
export class LoginComponent {
  readonly loginControl = viewChild.required(LoginControlComponent);
}
