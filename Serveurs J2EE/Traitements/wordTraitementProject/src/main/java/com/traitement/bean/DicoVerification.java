/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.traitement.bean;




import com.dao.model.Dico;
import java.io.Serializable;
import java.util.List;
import javax.persistence.EntityManager;


/**
 *
 * @author gueryacine
 */
public class DicoVerification extends ATraitementClass<Float> implements Serializable{
    
   //@PersistenceContext(unitName = "traitementProject_persistance")
    
    private EntityManager entityManager;
    private String QueryName = "Dico.findByMot";
    private String ColonneName = "mot";
    private String WordFoundConcatenated = "";
    private double Tauxdecorrespendence = 1;
    
    
    
    public void setEntityManager(EntityManager entityManager) {
        this.entityManager = entityManager;
    }

    public void setQueryName(String QueryName) {
        this.QueryName = QueryName;
    }

    public void setColonneName(String ColonneName) {
        this.ColonneName = ColonneName;
    }
    
    public String getWordFoundConcatenated() {
        return WordFoundConcatenated;
    }
    
    @Override
    public Double executerTraitement() {
        splitText();
        double countpart = 40;
        double conteur = 0;
        if(parts != null ){
            if( parts.length < 40)
            {
                countpart = parts.length;
            }
            
            for (int i = 0; i < countpart; i++) {
                
              if(compareWordwithDico(parts[i]))
              {
                  conteur++;
              }
              
            }
        }
        Tauxdecorrespendence = (conteur*100)/countpart;
        return Tauxdecorrespendence;
    }
    
    Boolean compareWordwithDico(String mot)
    {

        entityManager.getTransaction().begin();
        List<Dico> d1 = entityManager.createNamedQuery(QueryName).setParameter(ColonneName, mot).getResultList();
        entityManager.getTransaction().commit();

        if(d1.isEmpty() == false)
        {
            WordFoundConcatenated = WordFoundConcatenated + " " + mot;
            return true;
        }
        else
        {
        return false;
        }
    }
}
