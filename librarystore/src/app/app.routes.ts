import { Routes } from '@angular/router';
import { register } from 'module';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { BookComponent } from './components/book/book.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { SearchBookComponent } from './components/search-book/search-book.component';
import { UpdateBookComponent } from './components/update-book/update-book.component';
import { AddCategoryComponent } from './components/add-category/add-category.component';
import { SearchCategoryComponent } from './components/search-category/search-category.component';
import { UpdateCategoryComponent } from './components/update-category/update-category.component';
import { authGuard } from './auth.guard';
import { LogoutComponent } from './components/logout/logout.component';
import { CategoryComponent } from './components/category/category.component';
import { AddLoanComponent } from './components/add-loan/add-loan.component';
import { LoanComponent } from './components/loan/loan.component';
import { HomeComponent } from './components/home/home.component';
import { DefaultComponent } from './components/default/default.component';

export const routes: Routes = [
    { path: '', redirectTo: '/default', pathMatch: 'full' }, 
    {path:'default',component:DefaultComponent},
    {path:'home',component:HomeComponent},
    {path:'loan',component:LoanComponent,canActivate:[authGuard]},
    {path:'book',component:BookComponent,canActivate:[authGuard]},
    {path:'addbook',component:AddBookComponent,canActivate:[authGuard]},
    {path:'searchbook',component:SearchBookComponent,canActivate:[authGuard]},
    {path:'updatebook',component:UpdateBookComponent,canActivate:[authGuard]},
    { path: 'updatebook/:id', component: UpdateBookComponent ,canActivate:[authGuard]},
    { path: 'updatecategory/:id', component: UpdateCategoryComponent ,canActivate:[authGuard]},
    {path:'category',component:CategoryComponent,canActivate:[authGuard]},
    {path:'addcategory',component:AddCategoryComponent,canActivate:[authGuard]},
    {path:'searchcategory',component:SearchCategoryComponent,canActivate:[authGuard]},
    {path:'updatecategory',component:UpdateCategoryComponent,canActivate:[authGuard]},
    {path:'addloan',component:AddLoanComponent,canActivate:[authGuard]},
    {path:'login',component:LoginComponent},
    {path:'register',component:RegisterComponent},
    {path:'logout',component:LogoutComponent}



    
];
