import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class deducionesService {


     public baseUrl: string = "http://192.168.160.189:9095/api/";
  // public baseUrl: string= "https://localhost:44386/api/"
   //public baseUrl: string= "https://localhost:5001/api/"
  constructor(
    private http: HttpClient
  ) { }

  getAllVariables() {
    return this.http.get<any[]>(`${this.baseUrl}Deducione`);
  }

  postDeduciones(id: string, changes: Partial<any>) {
    return this.http.post(`${this.baseUrl}Deducione/${id}`, changes);
    
  }
  /*getVariables(id: string) {
    return this.http.get<any>(`${this.baseUrl}Variable/${id}`);
  }

  createVariables(any: any) {
    return this.http.post(`${this.baseUrl}Variable`, any);
  }

  updateVariables(id: string, changes: Partial<any>) {
    return this.http.put(`${this.baseUrl}Variable/${id}`, changes);
  }

  deleteVariables(id: string) {
    return this.http.delete(`${this.baseUrl}Variable/${id}`);
  }*/
}
   
