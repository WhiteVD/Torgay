// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component } from '@angular/core';
import { MatAnchor } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

import { fadeInOut } from '../../services/animations';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';

@Component({
    selector: 'app-about',
    templateUrl: './about.component.html',
    styleUrl: './about.component.scss',
    animations: [fadeInOut],
    imports: [PageHeaderComponent, MatAnchor, MatIcon]
})
export class AboutComponent {
}
