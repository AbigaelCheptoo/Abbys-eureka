import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import{environment} from 'src/environments/environment';
import { Observable } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class BankAccountService {

  constructor(private http:HttpClient) { }
  postBankAccount(formData: any) {
    return this.http.post(environment.apiBaseURI +'/BankAccount',formData);
  }
  putBankAccount(formData: any) {
    return this.http.put(environment.apiBaseURI +'/BankAccount/'+formData.bankAccountID,formData);
  }
  deleteBankAccount(id) {
    return this.http.delete(environment.apiBaseURI +'/BankAccount/' + id);
  }




  getBankAccountList():Observable<any[]> {
    return this.http.get<any[]>(environment.apiBaseURI +'/BankAccount');
  }
  
}

