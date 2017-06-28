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
public abstract class ATraitementClass<T> implements IDocumentCheck {
    
    private String doccumentText;
    public String[] parts;
    
    @Override
    public void setDocumentText(String text) {
        doccumentText = text;
    }

    @Override
    public String getDocumentText() {
        return doccumentText;
    }

    public void splitText() {
        parts = doccumentText.split(" +");
    }

}
