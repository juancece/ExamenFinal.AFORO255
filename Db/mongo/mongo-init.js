print('************* Start ********************');

db = db.getSiblingDB('db_transaction');
db.createCollection('Transaction');
db.Transaction.insert(
    {
        IdTransaction: 1,
        IdInvoice: 1,
        Amount: 50.00,
        Date: ISODate("2020-08-29T00:00:00Z")
    }
);