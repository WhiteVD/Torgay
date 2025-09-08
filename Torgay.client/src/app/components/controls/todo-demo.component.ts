// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, OnInit, OnDestroy, AfterViewInit, inject, input, viewChild } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort, MatSortHeader } from '@angular/material/sort';
import {
  MatTableDataSource, MatTable, MatColumnDef, MatHeaderCellDef, MatHeaderCell, MatCellDef, MatCell,
  MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow
} from '@angular/material/table';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatSlideToggle } from '@angular/material/slide-toggle';
import { MatProgressBar } from '@angular/material/progress-bar';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatButton, MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatTooltip } from '@angular/material/tooltip';
import { TranslateModule } from '@ngx-translate/core';

import { AuthService } from '../../services/auth.service';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AppTranslationService } from '../../services/app-translation.service';
import { LocalStoreManager } from '../../services/local-store-manager.service';
import { Utilities } from '../../services/utilities';
import { AddTaskDialogComponent } from './add-task-dialog.component';

export interface ToDoTask {
  name: string;
  description: string;
  isImportant: boolean;
  isComplete: boolean;
}

@Component({
  selector: 'app-todo-demo',
  templateUrl: './todo-demo.component.html',
  styleUrl: './todo-demo.component.scss',
  imports: [
    MatFormField, MatLabel, MatInput, MatSlideToggle, MatProgressBar, MatTable, MatSort, MatColumnDef,
    MatHeaderCellDef, MatHeaderCell, MatCheckbox, MatCellDef, MatCell, MatSortHeader, MatButton, MatIcon,
    MatIconButton, MatTooltip, MatHeaderRowDef, MatHeaderRow, MatRowDef, MatRow, MatPaginator, TranslateModule
  ]
})
export class TodoDemoComponent implements OnInit, AfterViewInit, OnDestroy {
  private alertService = inject(AlertService);
  private translationService = inject(AppTranslationService);
  private localStorage = inject(LocalStoreManager);
  private authService = inject(AuthService);
  private snackBar = inject(MatSnackBar);
  dialog = inject(MatDialog);

  public static readonly DBKeyTodoDemo = 'todo-demo.todo_list';

  displayedColumns = ['select', 'name', 'description', 'actions'];
  dataSource: MatTableDataSource<ToDoTask>;
  completedTasks: SelectionModel<ToDoTask>;
  isDataLoaded = false;
  loadingIndicator = true;
  formResetToggle = true;
  private _currentUserId: string | undefined;
  private _hideCompletedTasks = false;

  readonly paginator = viewChild.required(MatPaginator);

  readonly sort = viewChild.required(MatSort);

  readonly WidgetMode = input(false);

  constructor() {
    this.dataSource = new MatTableDataSource<ToDoTask>();
    this.completedTasks = new SelectionModel<ToDoTask>(true, []);
  }

  ngOnInit() {
    this.loadingIndicator = true;

    this.fetch(data => {
      this.dataSource.data = data;
      this.completedTasks = new SelectionModel<ToDoTask>(true, data.filter(x => x.isComplete));
      this.isDataLoaded = true;

      setTimeout(() => { this.loadingIndicator = false; }, 1500);
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator();
    this.dataSource.sort = this.sort();
    this.dataSource.filterPredicate = (data, filter) => this.filterData(data, filter);
  }

  ngOnDestroy() {
    this.saveToDisk();
  }

  toggleCompletedTasks() {
    this.hideCompletedTasks = !this.hideCompletedTasks;
    this.refresh();
  }

  refresh() {
    // Causes the filter to refresh there by updating with recently added data.
    this.applyFilter(this.dataSource.filter);
  }

  toggleAllTasksComplete() {
    if (this.areAllTasksComplete) {
      this.completedTasks.clear();
      this.dataSource.data.forEach(task => {
        task.isComplete = false;
      });
    } else {
      this.dataSource.data.forEach(task => {
        task.isComplete = true;
        this.completedTasks.select(task);
      });
    }
  }

  toggleTaskComplete(task: ToDoTask) {
    task.isComplete = !task.isComplete;
    this.completedTasks.select(task);
  }

  applyFilter(filterValue: string) {
    if (filterValue.length < 1) {
      filterValue = ' ';
    }

    this.dataSource.filter = filterValue;
  }

  fetch(callback: (data: ToDoTask[]) => void) {
    let data = this.getFromDisk();

    if (data == null) {
      setTimeout(() => {
        data = this.getFromDisk();

        if (data == null) {
          data = [
            {
              isComplete: true,
              isImportant: true,
              name: 'Create visual studio extension',
              description: 'Create a visual studio VSIX extension package that will add this project as an aspnet-core project template'
            },
            {
              isComplete: false,
              isImportant: true,
              name: 'Do a quick how-to writeup',
              description: ''
            },
            {
              isComplete: false,
              isImportant: false,
              name: 'Create aspnet-core/Angular tutorials based on this project',
              description: 'Create tutorials (blog/video/youtube) on how to build applications (full stack)' +
                ' using aspnet-core/Angular. The tutorial will focus on getting productive with the technology right away rather than the details on how and why they work so audience can get onboard quickly.'
            },
          ];
        }

        callback(data);
      }, 1000);
    } else {
      callback(data);
    }
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  addTask() {
    const dialogRef = this.dialog.open(AddTaskDialogComponent,
      {
        panelClass: 'mat-dialog-sm',
      });
    dialogRef.afterClosed().subscribe(newTask => {
      if (newTask) {
        this.dataSource.data.push(newTask);
        this.refresh();
        this.saveToDisk();
      }
    });
  }

  confirmDelete(task: ToDoTask) {
    this.snackBar.open('Delete the task?', 'DELETE', { duration: 5000 })
      .onAction().subscribe(() => {
        this.dataSource.data = this.dataSource.data.filter(item => item !== task);
        this.saveToDisk();
      });
  }

  getFromDisk() {
    return this.localStorage.getDataObject<ToDoTask[]>(`${TodoDemoComponent.DBKeyTodoDemo}:${this.currentUserId}`);
  }

  saveToDisk() {
    if (this.isDataLoaded) {
      this.localStorage.saveSyncedSessionData(this.dataSource.data, `${TodoDemoComponent.DBKeyTodoDemo}:${this.currentUserId}`);
    }
  }

  private filterData(task: ToDoTask, filter: string): boolean {
    return !(task.isComplete && this.hideCompletedTasks) && Utilities.searchArray(filter, false, task.name, task.description);
  }

  get currentUserId() {
    if (this.authService.currentUser) {
      this._currentUserId = this.authService.currentUser.id;
    }

    return this._currentUserId;
  }

  get areAllTasksComplete(): boolean {
    return this.completedTasks.selected.length === this.dataSource.data.length;
  }

  get hideCompletedTasks() {
    return this._hideCompletedTasks;
  }
  set hideCompletedTasks(value: boolean) {
    this._hideCompletedTasks = value;
  }
}
