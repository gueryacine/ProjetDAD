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

    public Responseclass(Boolean FindEmail, String Cle, String email,String FileName) {
        this.FindEmail = FindEmail;
        this.Cle = Cle;
        this.email = email;
        this.FileName = FileName;
    }
    public String FileName;
    public Boolean FindEmail;
    public String Cle;
    public String email;
    
}
