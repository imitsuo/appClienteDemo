import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Rx';
import { of } from 'rxjs/observable/of';

import { client } from '../client';


let todos: client[]; 

let headers = new Headers({ 'Content-Type': 'application/json' });
let options = new RequestOptions({ headers: headers });

@Injectable()
export class ClientService {

    private url: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl + "api/Client";
     }

    get() {
        
        console.log('url ' + this.url);
        return this.http.get(this.url)
            .map(res => res.json());
    }

    getClient(id: number) {

        
        return this.http.get(this.url + '/' + id)
            .map(res => res.json())
    }

    add(data: client) {
        
        return this.http.post(this.url, JSON.stringify(data), options)
        .map(res => res.json());
    }

    put(data: client) {
        
        return this.http.put(this.url, JSON.stringify(data), options)
        .map(res => res.json());
    }

    delete(id: number) {
        
        return this.http.delete(this.url + "/" + id)
        .map(res => res.json());
    }


}