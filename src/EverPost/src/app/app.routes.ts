import { Routes } from '@angular/router';
import { LoginComponent } from './Pages/login/login.component';
import { register } from 'module';
import { RegisterComponent } from './Pages/register/register.component';
import { HomeComponent } from './Pages/home/home.component';
import { ListPostsComponent } from './components/list-posts/list-posts.component';

export const routes: Routes = [
    {path:"",component:LoginComponent},
    {path:"Register",component:RegisterComponent},
    {path:"Home",component:HomeComponent, children:[
        {path:"Post",component:ListPostsComponent}
    ]},
];
