# Fruitracers API

## Authentication

### POST - /token

*Exchange credentials for access token.*

    Request: {
        email: "...",
        password: "..."
    }

    Response: {
        userId: 1,
        expiration: "...",
        token: "..."
    }

### GET - /renew

*Renew access token before expiration.*

Auth

    Request: empty

    Response: {
        userId: 1,
        expiration: "...",
        token: "..."
    }

### GET - /logout

*Logout user and release access token.*

Auth

    Request: empty

    Response: empty

### POST - /changepsw

*Change the password for the currently logged in user.*

Auth

    Request: {
        oldPassword: "...",
        newPassword: "..."
    }

    Response: empty

***

## Users

### GET - /user

*Request data for the currently logged in user.*

Auth

    Request: empty

    Response: {
        email: "...",
        telephone: "...",
        cookieConsent: true,
        marketingConsent: true
        isDeliveryCompany: true,
        isAdmin: true,
        person*: {
            CF: "...",
            firstName: "...",
            lastName: "...",
            birthDate: "..."
        },
        supplier*: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "...",
            description: "..."
        },
        customerBusiness*: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "..."
        }
    }

### GET - /users/{id}

*Request data for a given user.*

    Request: empty

    Response: {
        email: "...",
        telephone: "...",
        person*: {
            CF: "...",
            firstName: "...",
            lastName: "...",
            birthDate: "..."
        },
        supplier*: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "...",
            description: "..."
        },
        customerBusiness*: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "..."
        }
    }

### POST - /users/person

*Register a new person.*

    Request: {
        email: "...",
        password: "...",
        telephone: "...",
        person: {
            CF: "...",
            firstName: "...",
            lastName: "...",
            birthDate: "..."
        }
    }

    Response: {
        userId: 1
    }

### POST - /users/supplier

*Register a new supplier.*

    Request: {
        email: "...",
        password: "...",
        telephone: "...",
        supplier: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "...",
            description: "..."
        }        
    }

    Response: {
        userId: 1
    }

### POST - /users/customerbusiness

*Register a new customer business.*

    Request: {
        email: "...",
        password: "...",
        telephone: "...",
        customerBusiness: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "..."
        }        
    }

    Response: {
        userId: 1
    }

### PUT - /users/person

*Updates the logged in person.*

Auth

    Request: {
        email: "...",
        telephone: "...",
        person: {
            CF: "...",
            firstName: "...",
            lastName: "...",
            birthDate: "..."
        }
    }

    Response: empty

### PUT - /users/supplier

*Updates the logged in supplier.*

Auth

    Request: {
        email: "...",
        telephone: "...",
        supplier: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "...",
            description: "..."
        }        
    }

    Response: empty

### PUT - /users/customerbusiness

*Updates the logged in customer business.*

Auth

    Request: {
        email: "...",
        telephone: "...",
        customerBusiness: {
            vatNumber: "...",
            businessName: "...",
            sdi: "...",
            pec: "...",
            legalForm: "..."
        }        
    }

    Response: empty

### DELETE - /users

*Deletes the currently logged in user.*

Auth

    Request: empty

    Response: empty

***

## Addresses

### GET - /addresses

*Request addresses for the currently logged in user.*

Auth

    Request: empty
    
    Response: {
        addresses: [
            {
                addressID: 1,
                description: "...",
                latitude: 1.0,
                longitude: 1.0
            }
        ]
    }

### POST - /addresses

*Adds a new address for the currently logged in user.*

Auth

    Request: {
        description: "...",
        latitude: 1.0,
        longitude: 1.0
    }

    Response: {
        addressID: 1
    }

### PUT - /addresses

*Updates the given address for the currently logged in user.*

Auth

    Request: {
        addressID: 1,
        description: "...",
        latitude: 1.0,
        longitude: 1.0
    }

    Response: empty

### DELETE - /addresses/{id}

*Deletes the given address.*

Auth

    Request: empty

    Response: empty

***

## Products

### GET - /suppliers/{id}/products

*Returns the list of all products for the given supplier.*

    Request: empty

    Response: {
        products: [
            {
                productID: 1,
                name: "...",
                description: "...",
                categories: [
                    {
                        categoryID: 1,
                        name: "..."
                    }
                ],
                prices: {
                    people: {
                        value: 1.0,
                        unitName: "...",
                        unitMultiplier: 1.0,
                        minimum: 1
                    },
                    businesses: {
                        value: 1.0,
                        unitName: "...",
                        unitMultiplier: 1.0,
                        minimum: 1
                    }
                }
            }
        ]
    }

### GET - /products/{id}

*Returns data for the given product.*

    Request: empty
    
    Response: {
        productID: 1,
        name: "...",
        description: "...",
        categories: [
            {
                categoryID: 1,
                name: "..."
            }
        ],
        prices: {
            people: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            },
            businesses: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            }
        }
    }

### POST - /products

*Adds a new product to the currently logged in supplier.*

Auth

    Request: {
        name: "...",
        description: "...",
        categories: [
            1, 2
        ],
        prices: {
            people: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            },
            businesses: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            }
        }
    }

    Response: {
        productID: 1
    }

### PUT - /products

*Updates the given product for the currently logged in supplier.*

Auth

    Request: {
        productID: 1,
        name: "...",
        description: "...",
        categories: [
            1, 2
        ],
        prices: {
            people: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            },
            businesses: {
                value: 1.0,
                unitName: "...",
                unitMultiplier: 1.0,
                minimum: 1
            }
        }
    }

### DELETE - /products/{id}

*Deletes the given product for the currently logged in supplier.*

Auth

    Request: empty

    Response: empty

***

## Images

### GET - /suppliers/{id}/images

### GET - /products/{id}/images

### POST - /supplier/images

### POST - /products/{id}/images

### DELETE - /images/{id}

***

## Cart / Orders

### GET - /cart

*Returns cart details for the currently logged in person.*

Auth

    Request: empty

    Response: {
        deliveryInfo: {
            address: {
                addressID: 1,
                description: "...",
                latitude: 1.0,
                longitude: 1.0
            },
            date: "...",
            timeSlot: {
                timeSlotID: 1,
                startTime: "...",
                finishTime: "..."
            }
        },
        details: [
            {
                product: {
                    productID: 1,
                    name: "...",
                    description: "...",
                    categories: [
                        {
                            categoryID: 1,
                            name: "..."
                        }
                    ]
                }
                quantity: 1
            }
        ]
    }

### PUT - /cart

### POST - /cart/details

### PUT - /cart/details

### DELETE -/cart/details/{id}

### PUT - /cart/confirm

***

## Categories

### GET - /categories

***

## Measurements Units

### GET - /units

***

## Time Slots

### GET - /timeslots

### POST - /timeslot/override

***

## Suppliers

### GET - /suppliers

### GET - /suppliers/locations

### GET - /suppliers/orders

