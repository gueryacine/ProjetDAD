package DAD.ejb;

import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.*;
import javax.jms.MessageListener;

/**
 *
 * @author gueryacine
 */
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "mydes")
    ,
        @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Queue")
})
public class MessageBeanService implements MessageListener {
    
    public MessageBeanService() {
    }
    
    @Override
    public void onMessage(Message message) {
        try {
            TextMessage textMessage = (TextMessage)message;
            if(textMessage != null){
                System.out.println(textMessage.getText());
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        
    }
    
}
