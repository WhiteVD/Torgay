import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { TranslateModule } from '@ngx-translate/core';

import { fadeInOut } from '../../services/animations';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';

@Component({
    selector: 'app-not-found',
    templateUrl: './not-found.component.html',
    styleUrl: './not-found.component.scss',
    animations: [fadeInOut],
    imports: [PageHeaderComponent, MatIcon, MatButton, RouterLink, TranslateModule]
})
export class NotFoundComponent {
}
