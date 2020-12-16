import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuanhuyenComponent } from './quanlichung/quanhuyen/quanhuyen.component';
import { ThanhphoComponent } from './quanlichung/thanhpho/thanhpho.component';
import { XaphuongComponent } from './quanlichung/xaphuong/xaphuong.component';
import {BaocaoComponent} from './baocao/baocao/baocao.component';

const routes: Routes = [
  {path:"thanhpho", component: ThanhphoComponent},
  {path:"quanhuyen", component: QuanhuyenComponent},
  {path:"xaphuong", component: XaphuongComponent},
  {path:"baocao" , component: BaocaoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
