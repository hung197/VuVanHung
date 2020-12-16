import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class XaphuongService {

  constructor(private http: HttpClient) { }
  getXaPhuongList() {
    return this.http.get(environment.apiBaseURI + '/XaPhuong');
  }
  postXaPhuong(formData) {
    return this.http.post(environment.apiBaseURI + '/XaPhuong', formData);
  }
  PutXaPhuong(formData) {
    return this.http.put(environment.apiBaseURI + '/XaPhuong/' + formData.MaXaPhuong, formData);
  }
  DeleteXaPhuong(id) {
    return this.http.delete(environment.apiBaseURI + '/XaPhuong/' + id);
  }
  getXaPhuongListByIdTp(id){
    return this.http.get(environment.apiBaseURI + '/XaPhuong/getXaPhuongListByIdTp/' +id);
    }
}
