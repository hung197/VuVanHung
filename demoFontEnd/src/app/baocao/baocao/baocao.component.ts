import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';
import { XaphuongService } from 'src/app/shared/xaphuong.service';

@Component({
  selector: 'app-baocao',
  templateUrl: './baocao.component.html',
  styles: []
})
export class BaocaoComponent implements OnInit {
  thanhphoForms: FormArray = this.fb.array([])
  thanhphoList = [];
  quanHuyenList = [];
  xaPhuongList = [];
  notification = null;
  constructor(private fb: FormBuilder, private thanhphoService: ThanhphoService,
    private quanhuyenService: QuanhuyenService, private xaphuongService: XaphuongService) { }

  ngOnInit(): void {
    this.thanhphoService.getThanhPhoList().subscribe(
      (res: any) => {
        this.thanhphoList = res;
        //console.log(res);
        
        this.thanhphoList.forEach(item => {
          this.quanhuyenService.getQuanHuyenListByIdTp(item.maTp).subscribe((resful: any[]) => {
            item.tenQuanHuyen = resful.map(x => x.tenQuanHuyen);
            this.xaphuongService.getXaPhuongListByIdTp(item.maTp).subscribe((ress: any[]) => {
                item.tenXaPhuong = ress.map(x => x.tenXaPhuong);
              });        
          });
        })
      });
  }
}
