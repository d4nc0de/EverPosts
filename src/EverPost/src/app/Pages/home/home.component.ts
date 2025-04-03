import { Component, inject, OnInit } from '@angular/core';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { PaginatorModule } from 'primeng/paginator';
import { Router, RouterOutlet } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { SidebarModule } from 'primeng/sidebar';
import { PostService } from '../../services/post.service';
import { MegaMenuModule } from 'primeng/megamenu';
import { MegaMenuItem } from 'primeng/api';

@Component({
  selector: 'app-home',
  imports: [AvatarModule,AvatarGroupModule,ButtonModule,CommonModule,CardModule,PaginatorModule,SidebarModule,MegaMenuModule, RouterOutlet],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
    items: MegaMenuItem[] | undefined;



    ngOnInit() {
        this.items = [
            {
                label: 'My Posts',
                root: true,
            },
            {
                label: 'Home Page',
                root: true
            },
            {
                label: 'Friends',
                root: true
            }
        ];
    }
  
}
