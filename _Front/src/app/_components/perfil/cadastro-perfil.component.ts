import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService, AlertService } from '@app/_services';
import { PerfilService } from '@app/_services/perfil.service';
import { Perfil, Permiss } from '@app/_models';

@Component({ templateUrl: 'cadastro-perfil.component.html' })
export class CadastroPerfilComponent implements OnInit {
 
    loading = false;
    submitted = false;
    perfil = new Perfil;
    Permissao = new Permiss;
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private perfilService: PerfilService,
        private alertService: AlertService
    ) { }

    ngOnInit() {
        this.perfil.permissoes = new Array<Permiss>;
    }

    public SalvarPerfil(){
        this.perfilService.salvarPerfil(this.perfil)
        .subscribe((dados : object) => {

            this.alertService.clear();
            this.alertService.info( this.perfil?.nome!)
          
          });

          
     }

     inserirlista(lista : Permiss[]){
       
        this.perfil.permissoes = lista;
    }
    public AdicionarPermissao(){
        this.perfil.permissoes?.push(this.Permissao);
        this.Permissao = new Permiss;
    }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

     

        this.loading = true;
        this.perfilService.salvarPerfil(this.perfil)
            .pipe(first())
            .subscribe({
                next: () => {
                    // get return url from query parameters or default to home page
                    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                    this.router.navigateByUrl(returnUrl);
                },
                error: error => {
                    this.alertService.error(error);
                    this.loading = false;
                }
            });
    }
}