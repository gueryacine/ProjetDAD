/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dao.model;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author gueryacine
 */
@Entity
@Table(name = "dechiffrage")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Dechiffrage.findAll", query = "SELECT d FROM Dechiffrage d")
    , @NamedQuery(name = "Dechiffrage.findByIdDechiffrage", query = "SELECT d FROM Dechiffrage d WHERE d.idDechiffrage = :idDechiffrage")
    , @NamedQuery(name = "Dechiffrage.findByPathTxtFichier", query = "SELECT d FROM Dechiffrage d WHERE d.pathTxtFichier = :pathTxtFichier")
    , @NamedQuery(name = "Dechiffrage.findByCleDecodage", query = "SELECT d FROM Dechiffrage d WHERE d.cleDecodage = :cleDecodage")
    , @NamedQuery(name = "Dechiffrage.findByTauxDeReussite", query = "SELECT d FROM Dechiffrage d WHERE d.tauxDeReussite = :tauxDeReussite")
    , @NamedQuery(name = "Dechiffrage.findByEmail", query = "SELECT d FROM Dechiffrage d WHERE d.email = :email")})
public class Dechiffrage implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id_dechiffrage")
    private Integer idDechiffrage;
    @Size(max = 25)
    @Column(name = "pathTxtFichier")
    private String pathTxtFichier;
    @Size(max = 25)
    @Column(name = "cleDecodage")
    private String cleDecodage;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Column(name = "tauxDeReussite")
    private Double tauxDeReussite;
    @Lob
    @Size(max = 65535)
    @Column(name = "fristswordfound")
    private String fristswordfound;
    // @Pattern(regexp="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", message="Invalid email")//if the field contains email address consider using this annotation to enforce field validation
    @Size(max = 25)
    @Column(name = "email")
    private String email;

    public Dechiffrage() {
    }

    public Dechiffrage(Integer idDechiffrage) {
        this.idDechiffrage = idDechiffrage;
    }

    public Integer getIdDechiffrage() {
        return idDechiffrage;
    }

    public void setIdDechiffrage(Integer idDechiffrage) {
        this.idDechiffrage = idDechiffrage;
    }

    public String getPathTxtFichier() {
        return pathTxtFichier;
    }

    public void setPathTxtFichier(String pathTxtFichier) {
        this.pathTxtFichier = pathTxtFichier;
    }

    public String getCleDecodage() {
        return cleDecodage;
    }

    public void setCleDecodage(String cleDecodage) {
        this.cleDecodage = cleDecodage;
    }

    public Double getTauxDeReussite() {
        return tauxDeReussite;
    }

    public void setTauxDeReussite(Double tauxDeReussite) {
        this.tauxDeReussite = tauxDeReussite;
    }

    public String getFristswordfound() {
        return fristswordfound;
    }

    public void setFristswordfound(String fristswordfound) {
        this.fristswordfound = fristswordfound;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idDechiffrage != null ? idDechiffrage.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Dechiffrage)) {
            return false;
        }
        Dechiffrage other = (Dechiffrage) object;
        if ((this.idDechiffrage == null && other.idDechiffrage != null) || (this.idDechiffrage != null && !this.idDechiffrage.equals(other.idDechiffrage))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.dao.model.Dechiffrage[ idDechiffrage=" + idDechiffrage + " ]";
    }
    
}
