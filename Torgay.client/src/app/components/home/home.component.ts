import { AfterViewInit, Component, ElementRef, inject, viewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CdkDragDrop, moveItemInArray, CdkDropList, CdkDrag, CdkDragPlaceholder, CdkDragHandle } from '@angular/cdk/drag-drop';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIcon } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconButton } from '@angular/material/button';
import { TranslateModule } from '@ngx-translate/core';

import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';
import { AuthService } from '../../services/auth.service';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';
import { StatisticsDemoComponent } from '../controls/statistics-demo.component';
import { NotificationsViewerComponent } from '../controls/notifications-viewer.component';
import { TodoDemoComponent } from '../controls/todo-demo.component';
import { BannerDemoComponent } from '../controls/banner-demo.component';

interface WidgetIndex { element: string, index: number }

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  animations: [fadeInOut],
  imports: [
    RouterLink, CdkDropList, CdkDrag, CdkDragHandle, CdkDragPlaceholder, MatCardModule, MatMenuModule, MatIconButton,
    MatDividerModule, MatIcon, PageHeaderComponent, StatisticsDemoComponent, NotificationsViewerComponent,
    TodoDemoComponent, BannerDemoComponent,
    TranslateModule
  ]
})
export class HomeComponent implements AfterViewInit {
  private authService = inject(AuthService);
  configurations = inject(ConfigurationService);

  readonly DBKeyWidgetsOrder = 'home-component.widgets_order';
  readonly widgetsContainer = viewChild.required<ElementRef<HTMLDivElement>>('widgetsContainer');

  showStatisticsDragIcon = false;
  showNotificationsDragIcon = false;
  showTodoDragIcon = false;
  showBannerDragIcon = false;

  get dragStartDelay() {
    return (
      this.showStatisticsDragIcon ||
      this.showNotificationsDragIcon ||
      this.showTodoDragIcon ||
      this.showBannerDragIcon
    ) ? 0 : 500;
  }

  ngAfterViewInit(): void {
    this.restoreWidgetsOrder();
  }

  restoreWidgetsOrder() {
    const widgetIndexes = this.loadWidgetIndexes();

    if (widgetIndexes == null || widgetIndexes.length == 0)
      return;

    const parentEle = this.widgetsContainer().nativeElement;

    for (const widget of Array.from(parentEle.children)) {
      const index = widgetIndexes.find(w => w.element == widget.id)?.index;

      if (index != null)
        this.insertChildAtIndex(parentEle, widget, index);
    }
  }

  showDragIcon(icon: 'statistics' | 'notifications' | 'todo' | 'banner') {
    const timeoutTime = 10000;

    if (icon === 'statistics') {
      this.showStatisticsDragIcon = true;
      setTimeout(() => this.showStatisticsDragIcon = false, timeoutTime);
    }
    else if (icon === 'notifications') {
      this.showNotificationsDragIcon = true;
      setTimeout(() => this.showNotificationsDragIcon = false, timeoutTime);
    }
    else if (icon === 'todo') {
      this.showTodoDragIcon = true;
      setTimeout(() => this.showTodoDragIcon = false, timeoutTime);
    }
    else if (icon === 'banner') {
      this.showBannerDragIcon = true;
      setTimeout(() => this.showBannerDragIcon = false, timeoutTime);
    }
  }

  hideDragIcons() {
    this.showStatisticsDragIcon = false;
    this.showNotificationsDragIcon = false;
    this.showTodoDragIcon = false;
    this.showBannerDragIcon = false;
  }

  getPlaceholderMinHeight(placeholder: HTMLElement, widget: HTMLElement) {
    const placeholderMinHeight = parseInt(placeholder.style.minHeight, 10);
    return placeholderMinHeight || widget.offsetHeight;
  }

  insertChildAtIndex(parent: HTMLDivElement, child: Element, index: number) {
    if (!index)
      index = 0;

    if (index >= parent.children.length) {
      parent.appendChild(child);
    } else {
      parent.insertBefore(child, parent.children[index]);
    }
  }

  drop(event: CdkDragDrop<HTMLDivElement>) {
    const el = event.item.element.nativeElement;
    const parentEle = event.container.element.nativeElement;
    const anchorEle = parentEle.children[event.currentIndex];

    const widgetIndexes = new Array<WidgetIndex>(parentEle.children.length);

    for (let i = 0; i < parentEle.children.length; i++) {
      widgetIndexes[i] = { element: parentEle.children[i].id, index: i };
    }

    moveItemInArray(widgetIndexes, event.previousIndex, event.currentIndex);

    for (let i = 0; i < widgetIndexes.length; i++) {
      widgetIndexes[i].index = i;
    }

    if (event.currentIndex < event.previousIndex)
      parentEle.insertBefore(el, anchorEle);
    else
      parentEle.insertBefore(el, anchorEle.nextElementSibling);

    this.saveWidgetIndexes(widgetIndexes);
    this.hideDragIcons();
  }

  saveWidgetIndexes(indexes: WidgetIndex[]) {
    this.configurations
      .saveConfiguration(indexes, `${this.DBKeyWidgetsOrder}:${this.authService.currentUser?.id}`);
  }

  loadWidgetIndexes() {
    return this.configurations
      .getConfiguration<WidgetIndex[]>(`${this.DBKeyWidgetsOrder}:${this.authService.currentUser?.id}`);
  }

}
