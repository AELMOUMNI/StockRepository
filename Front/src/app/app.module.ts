import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ArticleApiService } from './core/services/article-api-service';
import { SearchPipe } from './shared/search.pipe';
import { StockDashboardComponent } from './stock-dashboard/stock-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    StockDashboardComponent,
    SearchPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ArticleApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
