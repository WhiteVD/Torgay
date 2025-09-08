// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

import { Component, ViewEncapsulation } from '@angular/core';
import { MatCarouselModule } from '@magloft/material-carousel';

@Component({
    selector: 'app-banner-demo',
    templateUrl: './banner-demo.component.html',
    styleUrl: './banner-demo.component.scss',
    encapsulation: ViewEncapsulation.None,
    imports: [MatCarouselModule]
})
export class BannerDemoComponent {

  carouselSlides = [
    {
      img: 'images/demo/banner1.png',
      alt: 'ASP.NET',
      caption: 'Learn how to build ASP.NET apps that can run anywhere',
      link: 'http://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409'
    },
    {
      img: 'images/demo/banner2.png',
      alt: 'Visual Studio',
      caption: 'One platform for building modern web, native mobile and native desktop applications',
      link: 'http://angular.dev'
    },
    {
      img: 'images/demo/banner3.png',
      alt: 'Package Management',
      caption: 'Bring in libraries from NuGet and npm, and bundle with angular/cli',
      link: 'http://go.microsoft.com/fwlink/?LinkID=525029&clcid=0x409'
    },
    {
      img: 'images/demo/banner4.png',
      alt: 'Eben Monney',
      caption: 'Follow me on social media for updates and tips on using this startup project',
      link: 'https://www.ebenmonney.com/about'
    }
  ];
}
