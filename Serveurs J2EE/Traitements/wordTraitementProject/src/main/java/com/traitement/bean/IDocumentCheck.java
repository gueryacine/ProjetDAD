/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.traitement.bean;

/**
 *
 * @author gueryacine
 */
public interface IDocumentCheck<T> {
    
  void setDocumentText(String Text);
  
  String getDocumentText();

  public T executerTraitement();
}
