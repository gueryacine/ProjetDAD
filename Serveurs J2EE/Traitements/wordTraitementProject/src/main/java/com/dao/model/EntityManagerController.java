/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dao.model;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.PersistenceContext;

/**
 *
 * @author gueryacine
 */
public class EntityManagerController {
//    @PersistenceContext("com_wordTraitementProject_ejb_1.0-SNAPSHOTPU")
    private EntityManagerFactory emf;
     
     private EntityManager em;

    public EntityManagerFactory getEmf() {
        return emf;
    }

    public void setEmf(EntityManagerFactory emf) {
        this.emf = emf;
    }

    public EntityManager getEm() {
        return em;
    }

    public void setEm(EntityManager em) {
        this.em = em;
    }

    public EntityManagerController() {
        emf = Persistence.createEntityManagerFactory("newPU");
        em = emf.createEntityManager();
        
    }
     
     
    
    
    
}
