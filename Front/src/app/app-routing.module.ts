import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockDashboardComponent } from './stock-dashboard/stock-dashboard.component';

const routes: Routes = [
  { path: 'articles', component: StockDashboardComponent },
  { path: '', redirectTo: '/articles', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
