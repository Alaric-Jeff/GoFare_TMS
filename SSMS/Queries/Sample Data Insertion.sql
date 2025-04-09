INSERT INTO ClientsModel (first_name, last_name, middle_name, age, address, gender)  
VALUES ('Jeffrey', 'Aspiras', 'M', 30, '123 Main St', 'Male');
INSERT INTO WalletsModel (client_id, balance, status, loaned)  
VALUES (1, 1000.00, 'Default', 0);
INSERT INTO RFIDModel (client_id, rfid)  
VALUES (1, 'B5 B9 B 5');


INSERT INTO ClientsModel (first_name, last_name, middle_name, age, address, gender)
VALUES ('Alice', 'Johnson', 'K', 28, '456 Oak Street', 'Female');
INSERT INTO WalletsModel (client_id, balance, status, loaned)
VALUES (2, 100.00, 'Loaned', 100);
INSERT INTO RFIDModel (client_id, rfid)
VALUES (2, '3E 8D 40 2');



