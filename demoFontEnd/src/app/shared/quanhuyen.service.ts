import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuanhuyenService {

  constructor(private http : HttpClient) { }
  getQuanHuyenList(){
  return this.http.get(environment.apiBaseURI + '/QuanHuyen');
  }
  postQuanHuyen(formData){
return this.http.post(environment.apiBaseURI + '/QuanHuyen', formData);
  }
  DeleteQuanHuyen(id) {
    return this.http.delete(environment.apiBaseURI + '/QuanHuyen/' + id);
  }
  PutQuanHuyen(formData) {
    return this.http.put(environment.apiBaseURI + '/QuanHuyen/' + formData.MaQuanHuyen, formData);
  }
  getQuanHuyenListByIdTp(id){
    return this.http.get(environment.apiBaseURI + '/QuanHuyen/QuanHuyenByIdThanhPho/' +id);
    }

}
