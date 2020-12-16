import { XaphuongService } from './../../shared/xaphuong.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-xaphuong',
  templateUrl: './xaphuong.component.html',
  styles: []
})
export class XaphuongComponent implements OnInit {
  xaphuongForms: FormArray = this.fb.array([]);
  thanhphoList = [];
  quanhuyenList = [];
  xaphuongList = [];
  quanhuyenAll = [];
  notification = null;
  constructor(private fb: FormBuilder, private quanhuyenService: QuanhuyenService,
    private thanhphoService: ThanhphoService, private xaphuongService: XaphuongService) { }

  ngOnInit(): void {
    this.thanhphoService.getThanhPhoList()
      .subscribe(res => this.thanhphoList = res as []);
    this.quanhuyenService.getQuanHuyenList().subscribe(res => {
      this.quanhuyenList = res as []
      this.quanhuyenAll = res as []
      console.log(this.quanhuyenAll)
      this.xaphuongService.getXaPhuongList().subscribe(
        (res: any) => {
          this.xaphuongList = res;
          if (res == [])
            this.addXaPhuongForm();
          else
            (res as []).forEach((XaPhuong: any) => {
              var data = this.quanhuyenAll.filter(x => x.maTp == XaPhuong.maTp)
              this.xaphuongForms.push(this.fb.group({
                MaXaPhuong: [XaPhuong.maXaPhuong],
                TenXaPhuong: [XaPhuong.tenXaPhuong, Validators.required],
                MaQuanHuyen: [XaPhuong.maQuanHuyen, Validators.min(1)],
                MaTp: [XaPhuong.maTp, Validators.min(1)],
                quanhuyenList: [data]
              }));
            });

          console.log(this.xaphuongForms.getRawValue());

        }
      );

    }
    );
    //this.addXaPhuongForm();
  }
  addXaPhuongForm() {
    this.xaphuongForms.push(this.fb.group({
      MaXaPhuong: [0],
      TenXaPhuong: [''],
      MaTp: [0],
      MaQuanHuyen: [0],
     quanhuyenList: [this.quanhuyenAll],
    //  notification: false
    }));
  }
  recordSubmit(st: FormGroup) {
    if (st.value.MaXaPhuong == 0)
      this.xaphuongService.postXaPhuong(st.value).subscribe(
        (res: any) => {
          st.patchValue({ MaXaPhuong: res.maXaPhuong });
          // this.showNotification('insert', st);
          alert('Thêm thành công!');
        }
      );
    else
      this.xaphuongService.PutXaPhuong(st.value).subscribe(
        (res: any) => {
          // this.showNotification('update', st);
          alert('Sửa thành công!');
        }
      );
  }
  ChangeThanhpho(value, st) {
    st.get('MaQuanHuyen').setValue(null);
    st.get('quanhuyenList').setValue(this.quanhuyenAll.filter(x => x.maTp == value))
    // this.quanhuyenList = this.quanhuyenList.filter(x => x.maTp == value);
  }
  // showNotification(category, st) {
  //   switch (category) {
  //     case 'insert':
  //       st.notification = { class: ' btn-success', message: 'Thêm mới thành công!' };
  //       break;
  //     case 'update':
  //       st.notification = { class: ' text-primary', message: 'Cập nhập thành công!' };
  //       break;
  //     case 'delete':
  //       this.notification = { class: ' text-danger', message: 'Xóa thành công!' };
  //       break;
  //     default:
  //       break;
  //   }
  //   setTimeout(() => {
  //     st.notification = null;
  //     this.notification = null;
  //   }, 3000);
  // }
  onDelete(MaXaPhuong, i, st) {
    if (confirm('Bạn có chắc chắn muốn xóa xã/phường ra khỏi danh sách?'))
      this.quanhuyenService.DeleteQuanHuyen(MaXaPhuong).subscribe(
        res => {
          this.xaphuongForms.removeAt(i);
          // this.showNotification('delete', st);
          alert('Xóa thành công!');
        });
  }

}
