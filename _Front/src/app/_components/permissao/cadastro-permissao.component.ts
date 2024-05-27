import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountService, AlertService } from '@app/_services';
import { PerfilService } from '@app/_services/perfil.service';
import { Perfil, Permiss } from '@app/_models';
import { ListaPermissaoComponent } from './lista-permissao/lista-permissao.component';

@Component({ 
    templateUrl: 'cadastro-permissao.component.html',
selector: 'cadastro-permissao', })
export class CadastroPermissaoComponent implements OnInit {

    @Output() permissaoinserida = new EventEmitter();

    loading = false;
    submitted = false;
    perfil = new Perfil;
    permissao = new Permiss;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private perfilService: PerfilService,
        private alertService: AlertService
    ) { }

    ngOnInit() {
        this.perfil.permissoes = new Array<Permiss>();
    }



    public AdicionarPermissao(){
        this.perfil.permissoes?.push(this.permissao);
        this.permissaoinserida.emit( this.perfil.permissoes);
        this.permissao = new Permiss;
    }
    RemoverPermissao(p : Permiss){
       
        this.perfil.permissoes = this.perfil.permissoes?.filter(s=>s.nome != p.nome && s.url != p.url);
    }
 
}