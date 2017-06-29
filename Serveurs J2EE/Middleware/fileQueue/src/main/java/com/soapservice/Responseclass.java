/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.soapservice;

/**
 *
 * @author gueryacine
 */
public class Responseclass {

    public Responseclass(Boolean FindEmail, String Cle, String email) {
        this.FindEmail = FindEmail;
        this.Cle = Cle;
        this.email = email;
    }
    
    public Boolean FindEmail;
    public String Cle;
    public String email;
    
}
