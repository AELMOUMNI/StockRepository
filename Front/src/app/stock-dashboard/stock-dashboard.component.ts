import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { debounceTime, distinctUntilChanged, Subject, Subscription, switchMap } from 'rxjs';
import { Article, IArticle } from '../core/models/IArticle';
import { IResponseArticle } from '../core/models/IResponseArticle';
import { ArticleApiService } from '../core/services/article-api-service';


@Component({
  selector: 'app-stock-dashboard',
  templateUrl: './stock-dashboard.component.html',
  styles: [`
    em {float:right; color:#E05C65; padding-left:10px;}
    .error input {background-color:#E3C3C5;}
    .error ::-webkit-input-placeholder { color: #999; }
    .error :-moz-placeholder { color: #999; }
    .error ::-moz-placeholder {color: #999; }
    .error :ms-input-placeholder { color: #999; }
  `]
})
export class StockDashboardComponent implements OnInit {
  articlesData : IArticle[] = []
  articleObj : Article = new Article();
  formValue !: FormGroup;
  sub! : Subscription;
  errorMessage: string = '';
  showAdd !: boolean;
  showUpdate !: boolean;
  type = new FormControl();
  searchValue :string = '';
  //@ViewChild('closebutton') closebutton: any;
  
  constructor(private api: ArticleApiService , private formBuilder : FormBuilder, private router : Router){
    
  }
  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      reference: ['',Validators.required],
      name: ['', Validators.required],
      quantity: [''],
      price: [''],
      type: [''],
      isTakeWay:['']
    })
    this.sub = this.api.getStock().subscribe({
      next: articlesData =>{
          this.articlesData = articlesData.data
      },
      error: err => this.errorMessage = err
  });

  }
  addRow() {
    this.articleObj.reference = this.formValue.value.reference;
    this.articleObj.name= this.formValue.value.name;
    this.articleObj.quantity = this.formValue.value.quantity;
    this.articleObj.price = this.formValue.value.price;
    debugger
    let category = this.formValue.value.type == "0" ? 0 : 1;
    this.articleObj.type = category
    this.articleObj.isTakeWay = this.formValue.value.isTakeWay;
    this.api.addNew(this.articleObj).subscribe(()=>{
      this.api.getStock().subscribe((data: IResponseArticle) => {
        this.articlesData = data.data;
        
    });
    });
    
  }
  getArticles() {
    this.api.getStock()
    .subscribe(res=>{
      this.articlesData = res.articlesData;
    })
  }
  clickAddArticle(){
    this.formValue.reset();
    this.showAdd = true;
    this.showUpdate = false;
  }

  edit(){
    this.articleObj.reference = this.formValue.value.reference;
    this.articleObj.name = this.formValue.value.name;
    this.articleObj.quantity = this.formValue.value.quantity;
    debugger
    let category = this.formValue.value.type == "0" ? 0 : 1;
    this.articleObj.type = category
    this.articleObj.isTakeWay = this.formValue.value.isTakeWay;
    this.api.update(this.articleObj).subscribe(()=>{
      this.api.getStock().subscribe((data: IResponseArticle) => {
        this.articlesData = data.data;
    });
  });
 }
  onEdit(row : any){
    this.formValue.controls['reference'].setValue(row.reference);
    this.formValue.controls['name'].setValue(row.name);
    this.formValue.controls['quantity'].setValue(row.quantity);
    this.formValue.controls['price'].setValue(row.price);
    this.showUpdate = true;
    this.showAdd = false;
  }
  removeRow(row: any) {
    if (window.confirm('Voulez-vous vraiment supprimer cet enregistrement ?')){
    this.api.delete(row.reference).subscribe(() => {
      this.articlesData = this.articlesData.filter(
        (u: IArticle) => u.reference !== row.reference
      );
    });
  }}
  onTypeChange(value: string) {
    this.api.changeType(value);
  }
}

