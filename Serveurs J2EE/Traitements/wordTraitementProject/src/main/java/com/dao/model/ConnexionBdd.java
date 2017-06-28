/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dao.model;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 *
 * @author gueryacine
 */

public class ConnexionBdd {
  //public static void main(String[] args) {      
  public static void jerevien() {      

      try {
      Class.forName("org.mysql.Driver");
      System.out.println("Driver O.K.");

      String url = "jdbc:mysql://localhost:3306/dadjeepart";
      String user = "root";
      String passwd = "";

      Connection conn = DriverManager.getConnection(url, user, passwd);
      System.out.println("Connexion effective !");         
         
    } catch (Exception e) {
      e.printStackTrace();
    }      
  }
}