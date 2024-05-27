import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Permiss } from '@app/_models';

@Component({
  selector: 'app-lista-permissao',
  templateUrl: './lista-permissao.component.html'
})
export class ListaPermissaoComponent implements OnInit {

  @Input() public permissoes: Array<Permiss> | undefined;


  @Output() listapermissoes = new EventEmitter();

  constructor() { }

  ngOnInit(): void {    
  }
  Remover(permissao: Permiss){
  this.listapermissoes.emit(permissao);
  }

}
