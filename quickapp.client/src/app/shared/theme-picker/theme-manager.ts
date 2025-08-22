// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Injectable } from '@angular/core';

import { AppTheme } from '../../models/AppTheme';

@Injectable({
  providedIn: 'root'
})
export class ThemeManager {
  themes: AppTheme[] = [
    {
      id: 1,
      name: 'azure-blue',
      displayName: 'theme.AzureBlue',
      primary: '#005cbb',
      secondary: '#d7e3ff',
      isDefault: true,
    },
    {
      id: 2,
      name: 'rose-red',
      displayName: 'theme.RoseRed',
      primary: '#ba005c',
      secondary: '#ffd9e1',
    },
    {
      id: 3,
      name: 'magenta-violet',
      displayName: 'theme.MagentaViolet',
      primary: '#ffabf3',
      secondary: '#810081',
    },
    {
      id: 4,
      name: 'cyan-orange',
      displayName: 'theme.CyanOrange',
      primary: '#00dddd',
      secondary: '#004f4f',
    },
  ];

  public installTheme(theme: AppTheme) {
    if (theme == null || theme.isDefault) {
      this.removeStyle('theme');
    } else {
      this.setStyle('theme', `${theme.name}.css`);
    }
  }

  public getThemeByID(id: number): AppTheme {
    const theme = this.themes.find(theme => theme.id === id);

    if (!theme)
      throw new Error(`Theme with id "${id}" not found!`);

    return theme;
  }

  private setStyle(key: string, href: string) {
    this.getLinkElementForKey(key).setAttribute('href', href);
  }

  private removeStyle(key: string) {
    const existingLinkElement = this.getExistingLinkElementByKey(key);
    if (existingLinkElement) {
      document.head.removeChild(existingLinkElement);
    }
  }

  private getLinkElementForKey(key: string) {
    return this.getExistingLinkElementByKey(key) || this.createLinkElementWithKey(key);
  }

  private getExistingLinkElementByKey(key: string) {
    return document.head.querySelector(`link[rel="stylesheet"].${this.getClassNameForKey(key)}`);
  }

  private createLinkElementWithKey(key: string) {
    const linkEl = document.createElement('link');
    linkEl.setAttribute('rel', 'stylesheet');
    linkEl.classList.add(this.getClassNameForKey(key));
    document.head.appendChild(linkEl);
    return linkEl;
  }

  private getClassNameForKey(key: string) {
    return `style-manager-${key}`;
  }
}
