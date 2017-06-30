/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dao.model;

import java.io.Serializable;
import java.util.Enumeration;
import javax.annotation.Resource;
import javax.enterprise.context.SessionScoped;
import javax.inject.Inject;
import javax.inject.Named;
import javax.jms.BytesMessage;
import javax.jms.Destination;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.Queue;
import javax.jms.QueueConnection;
/**
 *
 * @author Ewen Auffret
 */
@Named(value="filePublisherBean")
@SessionScoped
public class FilePublisherBean implements Serializable {

  public FilePublisherBean()
  {}
  
  @Inject
  private JMSContext context;
  
  private Message message; 
  
  @Resource(lookup="mydes")
  private Queue fileParsingQueue;
  
  private String fileName;
  private String keyValue;
  private String decryptedText;
  
  public void addMessageToQueue() throws JMSException {
    Message message = context.createTextMessage();  
    message.setStringProperty("FileName", getFileName());
    message.setStringProperty("KeyValue", getKeyValue());
    message.setStringProperty("DecryptedText", getDecryptedText());

    context.createProducer().send(fileParsingQueue, message);
  }
  
      /**
     * @return the message
     */
    public Message getMessage() {
        return message;
    }

    /**
     * @param message the message to set
     */
    public void setMessage(Message message) {
        this.message = message;
    }

 
    /**
     * @return the fileName
     */
    public String getFileName() {
        return fileName;
    }

    /**
     * @param fileName the fileName to set
     */
    public void setFileName(String fileName) {
        this.fileName = fileName;
    }

    /**
     * @return the keyValue
     */
    public String getKeyValue() {
        return keyValue;
    }

    /**
     * @param keyValue the keyValue to set
     */
    public void setKeyValue(String keyValue) {
        this.keyValue = keyValue;
    }

    /**
     * @return the decryptedText
     */
    public String getDecryptedText() {
        return decryptedText;
    }

    /**
     * @param decryptedText the decryptedText to set
     */
    public void setDecryptedText(String decryptedText) {
        this.decryptedText = decryptedText;
    }


}