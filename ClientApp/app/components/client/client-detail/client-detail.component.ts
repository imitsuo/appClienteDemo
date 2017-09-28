import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { BasicValidators } from '../shared/validators';
import { ClientService } from '../shared/client.service';
import { client } from '../client';


@Component({
  selector: 'client-detail',
  templateUrl: './client-detail.component.html'
 
})

export class ClientDetailComponent implements OnInit {
  title : string = '';
  _client : client = new client();
  form: FormGroup;

  constructor(public formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private clientService : ClientService) { 
        this.form = formBuilder.group({
            name: ['', [
              Validators.required,
              Validators.minLength(3)
            ]],
            telefone: ['', [
              Validators.required,
              BasicValidators.telefone             
            ]],
            documento: ['', 
            [
              Validators.required,
              BasicValidators.cpfOrCnpj  
            ]]            
          });          
        }
    

  ngOnInit() { 
    console.log('init');   
    console.log('client ' + this._client.name);
    var id = this.route.params.subscribe(params => {
      var id = +params['id'];
      console.log('id' + id); 
      this.title = id ? 'Alterar Cliente' : 'Novo Cliente';

      if (!id)
      {
        this._client = new client();
        return;
      }

      this.clientService.getClient(Number(id))
        .subscribe(          
          data => {
            console.log(data);
            this._client = data;
          },
          response => {
            if (response.status == 404) {
              this.router.navigate(['NotFound']);
            }
          });
    });
  }

  save() {
    var result,
        value = this.form.value;
    
    if (this._client.id){
      
      value.id = this._client.id;
      
      this.clientService.put(value).subscribe(data =>
        {
          this.router.navigate(['clients', Date.now()])
        });
    } 
    else {
      this.clientService.add(value).subscribe(data =>
        {
          this.router.navigate(['clients', Date.now()]);
        });      
    }
        
  }

  init()
  {
    this._client = new client();
    this.form.reset();
  }
}
