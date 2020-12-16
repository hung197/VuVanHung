import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-thanhpho',
  templateUrl: './thanhpho.component.html',
  styles: []
})
export class ThanhphoComponent implements OnInit {
  thanhphoForms: FormArray = this.fb.array([])
  thanhphoList = [];
  notification = null;

  constructor(private fb: FormBuilder, private thanhphoService: ThanhphoService) { }

  ngOnInit(): void {
    this.thanhphoService.getThanhPhoList().subscribe(
      (res: any) => {
        this.thanhphoList = res;
        if (res == [])
          this.addThanhPhoForm();
        else
          (res as []).forEach((ThanhPho: any) => {
            this.thanhphoForms.push(this.fb.group({
              MaTp: [ThanhPho.maTp],
              TenTp: [ThanhPho.tenTp, Validators.required],

            }));
          });
      }
    );
  }
  addThanhPhoForm() {
    this.thanhphoForms.push(this.fb.group({
      MaTp: [0],
      TenTp: ['', Validators.required],
      // notification: false
    }));
  }
  recordSubmit(st: FormGroup) {
    if (st.value.MaTp == 0)
      this.thanhphoService.postThanhPho(st.value).subscribe(
        (res: any) => {
          st.patchValue({ MaTp: res.maTp });
          // this.showNotification('insert', st);
          alert('Thêm thành công!');
        }
      );
    else
      this.thanhphoService.PutThanhPho(st.value).subscribe(
        (res: any) => {
          // this.showNotification('update', st);
          alert('Sửa Thành Công!');
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

  onDelete(MaTp, i, st) {
    if (confirm('Bạn có chắc chắn muốn xóa thành phố ra khỏi danh sách?'))
      this.thanhphoService.DeleteThanhPho(MaTp).subscribe(
        res => {
          this.thanhphoForms.removeAt(i);
          // this.showNotification('delete', st);
          alert('Xóa Thành Công')
        });
  }


}


