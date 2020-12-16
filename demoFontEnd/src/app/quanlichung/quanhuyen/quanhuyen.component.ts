import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-quanhuyen',
  templateUrl: './quanhuyen.component.html',
  styles: []
})
export class QuanhuyenComponent implements OnInit {
  quanHuyenForms: FormArray = this.fb.array([])
  thanhphoList = [];
  quanHuyenList = [];
  notification = null;
  constructor(private fb: FormBuilder, private quanhuyenService: QuanhuyenService,
  private thanhphoService: ThanhphoService) { }

  ngOnInit(): void {
    this.thanhphoService.getThanhPhoList()
      .subscribe(res => this.thanhphoList = res as []);

    this.quanhuyenService.getQuanHuyenList().subscribe(
      (res: any) => {
        this.quanHuyenList = res;
        if (res == [])
          this.addQuanHuyenForm();
        else
          (res as []).forEach((QuanHuyen: any) => {
            this.quanHuyenForms.push(this.fb.group({
              MaQuanHuyen: [QuanHuyen.maQuanHuyen],
              TenQuanHuyen: [QuanHuyen.tenQuanHuyen, Validators.required],
              MaTp: [QuanHuyen.maTp, Validators.min(1)],
            }));
          });
      }
    );

  }
  addQuanHuyenForm() {
    this.quanHuyenForms.push(this.fb.group({
      MaQuanHuyen: [0],
      MaTp: [0, Validators.min(1)],
      TenQuanHuyen: ['', Validators.required],
      notification: false
    }));
  }
  recordSubmit(st: FormGroup) {
    if(st.value.MaQuanHuyen ==0)
    this.quanhuyenService.postQuanHuyen(st.value).subscribe(
      (res: any) => {
        st.patchValue({ MaQuanHuyen: res.maQuanHuyen });
        // this.showNotification('insert', st);
        alert('Thêm thành công!');
      }
    );
    else
    this.quanhuyenService.PutQuanHuyen(st.value).subscribe(
      (res:any) =>{
// this.showNotification('update', st);
alert('Sửa thành công!');
      }
    );
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
  onDelete(MaQuanHuyen, i, st) {
    if (confirm('Bạn có chắc chắn muốn xóa quận/huyện ra khỏi danh sách?'))
      this.quanhuyenService.DeleteQuanHuyen(MaQuanHuyen).subscribe(
        res => {
          this.quanHuyenForms.removeAt(i);
          // this.showNotification('delete', st);
          alert('Xóa thành công!');
        });
  }
}