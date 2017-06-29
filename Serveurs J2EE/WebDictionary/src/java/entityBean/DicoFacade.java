/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entityBean;

import entity.Dico;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

/**
 *
 * @author auffr
 */
@Stateless
public class DicoFacade extends AbstractFacade<Dico> {

    @PersistenceContext(unitName = "WebDictionaryPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public DicoFacade() {
        super(Dico.class);
    }
    
}
