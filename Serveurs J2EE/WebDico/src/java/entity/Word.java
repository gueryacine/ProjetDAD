/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author cepes
 */
@Entity
@Table(name = "word")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Word.findAll", query = "SELECT w FROM Word w")
    , @NamedQuery(name = "Word.findByIdword", query = "SELECT w FROM Word w WHERE w.idword = :idword")
    , @NamedQuery(name = "Word.findByWord", query = "SELECT w FROM Word w WHERE w.word = :word")
    , @NamedQuery(name = "Word.findByLastdateword", query = "SELECT w FROM Word w WHERE w.lastdateword = :lastdateword")})
public class Word implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "idword")
    private Integer idword;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 250)
    @Column(name = "word")
    private String word;
    @Column(name = "lastdateword")
    @Temporal(TemporalType.TIMESTAMP)
    private Date lastdateword;

    public Word() {
    }

    public Word(Integer idword) {
        this.idword = idword;
    }

    public Word(Integer idword, String word) {
        this.idword = idword;
        this.word = word;
    }

    public Integer getIdword() {
        return idword;
    }

    public void setIdword(Integer idword) {
        this.idword = idword;
    }

    public String getWord() {
        return word;
    }

    public void setWord(String word) {
        this.word = word;
    }

    public Date getLastdateword() {
        return lastdateword;
    }

    public void setLastdateword(Date lastdateword) {
        this.lastdateword = lastdateword;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idword != null ? idword.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Word)) {
            return false;
        }
        Word other = (Word) object;
        if ((this.idword == null && other.idword != null) || (this.idword != null && !this.idword.equals(other.idword))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "entity.Word[ idword=" + idword + " ]";
    }
    
}
