// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { TranslateModule } from '@ngx-translate/core';

@Component({
    selector: 'app-page-header',
    templateUrl: './page-header.component.html',
    styleUrl: './page-header.component.scss',
    imports: [MatIcon, TranslateModule]
})
export class PageHeaderComponent {
  readonly title = input<string>();

  readonly icon = input<string>();
}
