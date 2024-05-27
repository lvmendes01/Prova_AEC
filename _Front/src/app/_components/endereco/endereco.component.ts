import { Component, OnInit } from '@angular/core';
import { User } from '@app/_models';
import { EnderecoModel } from '@app/_models/enderecomodel';
import { RetornoApi } from '@app/_models/retornoapi';
import { AccountService, AlertService } from '@app/_services';
import { EnderecoService } from '@app/_services/endereco.service';

@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html'
})
export class EnderecoComponent implements OnInit {
  usuario: User | null;
  endereco= new EnderecoModel();
  loading = false;
  submitted = false;
  constructor(private accountService: AccountService,
    private alertService: AlertService,
    private enderecoService: EnderecoService,) {

    this.usuario = this.accountService.userValue;
     }

  ngOnInit(): void {

  }
  valuechange(searchValue: string): void {

    if(searchValue.length == 8){
      this.enderecoService.ObterDadosAtravesCep(searchValue)
      .subscribe((dados : RetornoApi) => {
        if(dados.resultado){
          this.endereco = dados.resultado as EnderecoModel ;
        }
      });
    }
  }
  Salvar(){


    this.endereco.usuarioId = parseInt(this.usuario?.id ?? '0');
    this.enderecoService.salvarEndereco(this.endereco)
    .subscribe((dados : RetornoApi) => {
      if(dados.status){


        this.alertService.success(dados.mensagem??"");

      }else{

        this.alertService.error(dados.mensagem??"");
      }
    });




  }
}
