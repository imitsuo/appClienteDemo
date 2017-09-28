import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';


import { ClientService } from './shared/client.service';
import { client } from './client';


@Component({
  selector: 'app-client',
  templateUrl: './client.component.html'
 
})

export class ClientComponent implements OnInit {
  clients : client[] = [];
  
  constructor(private clientService : ClientService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    
    this.router.routeReuseStrategy.shouldReuseRoute = function(){
      return false;
  };
  
  this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
          this.router.navigated = false;
          window.scrollTo(0, 0);
      }
  });

    this.clientService.get().subscribe(data =>  this.clients = data);
  }

  delete(client : client){
    if (confirm("Are you sure you want to delete " + client.name + "?")) {
      this.clientService.delete(client.id).subscribe(()=> {
        this.clientService.get().subscribe(data =>  this.clients = data);
        this.router.navigate(['clients']);
      },
        err => {
          alert("Could not delete user.");
        });
    }
    
  }


}
