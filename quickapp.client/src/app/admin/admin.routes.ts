// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Routes } from '@angular/router';

import { AuthGuard } from '../services/auth-guard';

export const adminRoutes: Routes = [
  {
    path: '',
    loadComponent: () => import('./admin.component').then(m => m.AdminComponent),
    children: [
      {
        path: '',
        redirectTo: 'users',
        pathMatch: 'full'
      },
      {
        path: 'users',
        loadComponent: () => import('./user-list/user-list.component').then(m => m.UserListComponent),
        canActivate: [AuthGuard],
        title: 'Admin | Users'
      },
      {
        path: 'roles',
        loadComponent: () => import('./role-list/role-list.component').then(m => m.RoleListComponent),
        canActivate: [AuthGuard],
        title: 'Admin | Roles'
      }
    ]
  }
];
